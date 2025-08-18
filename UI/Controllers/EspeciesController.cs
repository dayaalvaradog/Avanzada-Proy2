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
    public class EspeciesController : Controller
    {

        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;

        public EspeciesController(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _apiBaseUrl = configuration["AppSettings:ApiBaseUrl"];
        }

        public IActionResult Index()
        {
            return View();
        }

        #region Especies

        [HttpPost]
        public async Task<IActionResult> Index(Especie especie)
        {
            var json = JsonSerializer.Serialize(especie);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{_apiBaseUrl}/api/Especies", content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index"); 

            ModelState.AddModelError("", "Error al agregar la especie.");
            return View(especie);
        }
        public async Task<IActionResult> Agregar()
        {
            var viewModel = new EspecieViewModel();

            var response = await _httpClient.GetAsync($"{_apiBaseUrl}/api/Familias");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                viewModel.familias = JsonSerializer.Deserialize<List<Familia>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            else
            {
                viewModel.familias = new List<Familia>();
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Editar(int id)
        {
            // 1. Get the Especie data from the API
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}/api/Especies/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            var json = await response.Content.ReadAsStringAsync();
            var especie = JsonSerializer.Deserialize<Especie>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            // 2. Get the list of Familias from the API for the dropdown
            var familiasResponse = await _httpClient.GetAsync($"{_apiBaseUrl}/api/Familias");
            var familiasJson = await familiasResponse.Content.ReadAsStringAsync();
            var familias = JsonSerializer.Deserialize<List<Familia>>(familiasJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            // 3. Map the data to a new ViewModel
            var viewModel = new EspecieViewModel
            {
                idEspecie = especie.idEspecie,
                nombreCientifico = especie.nombreCientifico,
                nombreComun = especie.nombreComun,
                descripcion = especie.descripcion,
                idFamilia = especie.idFamilia,
                familias = familias 
            };

            // 4. Pass the ViewModel to the view
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Especie especie)
        {
            var json = JsonSerializer.Serialize(especie);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"{_apiBaseUrl}/api/Especies/{especie.idEspecie}", content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            ModelState.AddModelError("", "Error al editar la especie.");
            return View(especie);
        }

        public async Task<IActionResult> Eliminar(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_apiBaseUrl}/api/Especies/{id}");
            return RedirectToAction("Index");
        }

        #endregion

        #region Familias
        public IActionResult AgregarFamilia()
        {
            return View();
        }



        #endregion
    }
}
