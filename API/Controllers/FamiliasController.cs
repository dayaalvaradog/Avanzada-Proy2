using Core.Entidades;
using DataAccess.AccesoDatos;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamiliasController : ControllerBase
    {
        private readonly IFamilia _familiaAD;
        public FamiliasController(IFamilia familiaAD)
        {
            _familiaAD = familiaAD;
        }
        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _familiaAD.ObtenerTodas());
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var familia = await _familiaAD.ObtenerPorId(id);
            return familia == null ? NotFound() : Ok(familia);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Familia familia)
        {
            await _familiaAD.Agregar(familia);
            return CreatedAtAction(nameof(Get), new { id = familia.idFamilia }, familia);
        }
    }
}
