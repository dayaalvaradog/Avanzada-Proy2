using Core.Entidades;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SemillasController : ControllerBase
    {
        private readonly ISemilla _semillaAD;

        public SemillasController(ISemilla semillaAD)
        {
            _semillaAD = semillaAD;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _semillaAD.ObtenerTodas());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var semilla = await _semillaAD.ObtenerPorId(id);
            return semilla == null ? NotFound() : Ok(semilla);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Semilla semilla)
        {
            await _semillaAD.Agregar(semilla);
            return CreatedAtAction(nameof(Get), new { id = semilla.idSemilla }, semilla);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Semilla semilla)
        {
            if (id != semilla.idSemilla)
            {
                return BadRequest("El ID del objeto no coincide con el ID de la URL.");
            }

            try
            {
                await _semillaAD.Actualizar(semilla);
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _semillaAD.ObtenerPorId(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _semillaAD.Eliminar(id);
            return NoContent();
        }
    }
}
