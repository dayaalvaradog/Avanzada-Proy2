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
    public class UbicacionesController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;

        public UbicacionesController(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _apiBaseUrl = configuration["AppSettings:ApiBaseUrl"];
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Ubicacion ubicacion)
        {
            var json = JsonSerializer.Serialize(ubicacion);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{_apiBaseUrl}/api/Ubicaciones", content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            ModelState.AddModelError("", "Error al agregar la ubicación.");
            return View(ubicacion);
        }

        public IActionResult Agregar()
        {
            return View();
        }
    }
}
