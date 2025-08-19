using Core.Entidades;
using DataAccess.AccesoDatos;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportesController : ControllerBase
    {
        private readonly IReporte _reporteAD;

        public ReportesController(IReporte reporteAD)
        {
            _reporteAD = reporteAD;
        }

        [HttpGet("ObtenerTiposFrecuencia")]
        public async Task<IActionResult> ObtenerTiposFrecuencia() => Ok(await _reporteAD.ObtenerTipoFrecuencia());

        [HttpGet("ObtenerParametros/{id}")]
        public async Task<IActionResult> ObtenerParametros(int id)
        {
            var parametro = await _reporteAD.ObtenerParametros(id);
            return parametro == null ? NotFound() : Ok(parametro);
        }

        [HttpGet("ObtenerUbicacionesParametros/{id}")]
        public async Task<IActionResult> ObtenerUbicacionesParametros(int id)
        {
            var ubicaciones = await _reporteAD.ObtenerUbicacionesParametros(id);
            return ubicaciones == null ? NotFound() : Ok(ubicaciones);
        }

        [HttpGet("ObtenerEspeciesParametros/{id}")]
        public async Task<IActionResult> ObtenerEspeciesParametros(int id)
        {
            var especies = await _reporteAD.ObtenerEspeciesParametros(id);
            return especies == null ? NotFound() : Ok(especies);
        }

        [HttpGet("ObtenerDestinatarios/{id}")]
        public async Task<IActionResult> ObtenerDestinatarios(int id)
        {
            var destinatarios = await _reporteAD.ObtenerDestinatarios(id);
            return destinatarios == null ? NotFound() : Ok(destinatarios);
        }

        [HttpGet("ObtenerTodos")]
        public async Task<IActionResult> ObtenerTodas() => Ok(await _reporteAD.ObtenerTodas());

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var reporte = await _reporteAD.ObtenerPorId(id);
            return reporte == null ? NotFound() : Ok(reporte);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Reporte reporte)
        {
            await _reporteAD.Agregar(reporte);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = reporte.idReporte }, reporte);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Reporte reporte)
        {
            if (id != reporte.idReporte)
            {
                return BadRequest("El ID del objeto no coincide con el ID de la URL.");
            }

            try
            {
                await _reporteAD.Actualizar(reporte);
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _reporteAD.ObtenerPorId(id) == null)
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
            await _reporteAD.Eliminar(id);
            return NoContent();
        }


    }
}
