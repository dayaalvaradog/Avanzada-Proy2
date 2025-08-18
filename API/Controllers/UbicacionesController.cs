using Core.Entidades;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UbicacionesController : ControllerBase
    {
        private readonly IUbicacion _ubicacionAD;
        public UbicacionesController(IUbicacion ubicacionAD)
        {
            _ubicacionAD = ubicacionAD;
        }
        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _ubicacionAD.ObtenerTodas());
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var ubicacion = await _ubicacionAD.ObtenerPorId(id);
            return ubicacion == null ? NotFound() : Ok(ubicacion);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Ubicacion ubicacion)
        {
            await _ubicacionAD.Agregar(ubicacion);
            return CreatedAtAction(nameof(Get), new { id = ubicacion.idUbicacion }, ubicacion);
        }
    }
}
