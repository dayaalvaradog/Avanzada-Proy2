using Core.Entidades;
using DataAccess.Data;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspeciesController : ControllerBase
    {

        private readonly IEspecie _especieAD;

        public EspeciesController(IEspecie especieAD)
        {
            _especieAD = especieAD;
        }

        #region Especies

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _especieAD.ObtenerTodas());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var especie = await _especieAD.ObtenerPorId(id);
            return especie == null ? NotFound() : Ok(especie);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Especie especie)
        {
            await _especieAD.Agregar(especie);
            return CreatedAtAction(nameof(Get), new { id = especie.idEspecie }, especie);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Especie especie)
        {
            if (id != especie.idEspecie)
            {
                return BadRequest("El ID del objeto no coincide con el ID de la URL.");
            }

            try
            {
                await _especieAD.Actualizar(especie);
                return Ok(); 
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _especieAD.ObtenerPorId(id) == null)
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
            await _especieAD.Eliminar(id);
            return NoContent();
        }
        #endregion
    }
}
