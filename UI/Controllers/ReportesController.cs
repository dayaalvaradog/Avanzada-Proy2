using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using UI.Models;
using Core.Entidades;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace UI.Controllers
{
    public class ReportesController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;

        public ReportesController(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _apiBaseUrl = configuration["AppSettings:ApiBaseUrl"];
        }

        [HttpGet]
        public async Task<IActionResult> Agregar()
        {
            var viewModel = new ReporteViewModel();
            viewModel.Reporte = new Reporte(); 

            // Llama a la API para obtener todos los datos necesarios
            var tiposFrecuenciaResponse = await _httpClient.GetAsync($"{_apiBaseUrl}/api/Reportes/ObtenerTiposFrecuencia");
            var especiesResponse = await _httpClient.GetAsync($"{_apiBaseUrl}/api/Especies");
            var ubicacionesResponse = await _httpClient.GetAsync($"{_apiBaseUrl}/api/Ubicaciones");
            var destinatariosResponse = await _httpClient.GetAsync($"{_apiBaseUrl}/api/Reportes/ObtenerDestinatarios/0"); 

            // Deserializa las respuestas y las agrega al ViewModel
            if (tiposFrecuenciaResponse.IsSuccessStatusCode)
            {
                var json = await tiposFrecuenciaResponse.Content.ReadAsStringAsync();
                viewModel.TiposFrecuencia = JsonSerializer.Deserialize<List<TipoFrecuencia>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            if (especiesResponse.IsSuccessStatusCode)
            {
                var json = await especiesResponse.Content.ReadAsStringAsync();
                viewModel.Especies = JsonSerializer.Deserialize<List<Especie>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            if (ubicacionesResponse.IsSuccessStatusCode)
            {
                var json = await ubicacionesResponse.Content.ReadAsStringAsync();
                viewModel.Ubicaciones = JsonSerializer.Deserialize<List<Ubicacion>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            return View(viewModel);
        }
        public async Task<IActionResult> Index()
        {
            var viewModel = new ReporteIndexViewModel();
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}/api/Reportes/ObtenerTodos");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                viewModel.Reportes = JsonSerializer.Deserialize<List<Reporte>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            else
            {
                viewModel.Reportes = new List<Reporte>();
            }

            return View(viewModel);
        }
    }
}