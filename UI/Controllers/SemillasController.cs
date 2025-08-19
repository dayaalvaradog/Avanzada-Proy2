using Core.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UI.Models;

namespace UI.Controllers
{
    public class SemillasController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;

        public SemillasController(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _apiBaseUrl = configuration["AppSettings:ApiBaseUrl"];
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Semilla semilla)
        {
            var json = JsonSerializer.Serialize(semilla);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{_apiBaseUrl}/api/Semillas", content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            ModelState.AddModelError("", "Error al agregar la semilla.");
            return View(semilla);
        }
        public async Task<IActionResult> Agregar()
        {
            var viewModel = new SemillaViewModel();

            var response = await _httpClient.GetAsync($"{_apiBaseUrl}/api/Especies");
            var response2 = await _httpClient.GetAsync($"{_apiBaseUrl}/api/Ubicaciones");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                viewModel.especies = JsonSerializer.Deserialize<List<Especie>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            else
            {
                viewModel.especies = new List<Especie>();
            }

            if (response2.IsSuccessStatusCode)
            {
                var json2 = await response2.Content.ReadAsStringAsync();
                viewModel.ubicaciones = JsonSerializer.Deserialize<List<Ubicacion>>(json2, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            else
            {
                viewModel.ubicaciones = new List<Ubicacion>();
            }

                return View(viewModel);
        }

        public async Task<IActionResult> Editar(int id)
        {
            // 1. Get the Especie data from the API
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}/api/Semillas/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            var json = await response.Content.ReadAsStringAsync();
            var semilla = JsonSerializer.Deserialize<Semilla>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            // 2. Get the list of Especies y Ubicaciones from the API for the dropdown
            var especiesResponse = await _httpClient.GetAsync($"{_apiBaseUrl}/api/Especies");
            var especiesJson = await especiesResponse.Content.ReadAsStringAsync();
            var especies = JsonSerializer.Deserialize<List<Especie>>(especiesJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            var ubicacionesResponse = await _httpClient.GetAsync($"{_apiBaseUrl}/api/Ubicaciones");
            var ubicacionesJson = await ubicacionesResponse.Content.ReadAsStringAsync();
            var ubicaciones = JsonSerializer.Deserialize<List<Ubicacion>>(ubicacionesJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            // 3. Map the data to a new ViewModel
            var viewModel = new SemillaViewModel
            {
                idSemilla = semilla.idSemilla,
                nombre = semilla.nombre,
                idEspecie = semilla.idEspecie,
                idUbicacion = semilla.idUbicacion,
                especies = especies,
                ubicaciones = ubicaciones,
                cantidad = semilla.cantidad,
                fechaAlmacenamiento = semilla.fechaAlmacenamiento
            };

            // 4. Pass the ViewModel to the view
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Semilla semilla)
        {
            var json = JsonSerializer.Serialize(semilla);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"{_apiBaseUrl}/api/Semillas/{semilla.idSemilla}", content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            ModelState.AddModelError("", "Error al editar la semilla.");
            return View(semilla);
        }

        public async Task<IActionResult> Eliminar(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_apiBaseUrl}/api/Semillas/{id}");
            return RedirectToAction("Index");
        }
    }
}
