using Core.Entidades;
using DataAccess.Data;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.AccesoDatos
{
    public class ReporteAD : IReporte
    {
        private readonly ApplicationDbContext _context;

        public ReporteAD(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TipoFrecuencia>> ObtenerTipoFrecuencia() => await _context.TiposFrecuencia.ToListAsync();
        
        public async Task<Parametro> ObtenerParametros(int id) => await _context.Parametros.FindAsync(id);
        
        public async Task<List<Destinatario>> ObtenerDestinatarios(int id)
        {
            return await _context.Destinatarios
                                 .Include(e => e.idDestinatario)
                                 .Where(d => d.idDestinatario == id)
                                 .ToListAsync();
        }

        public async Task<List<Especies_Parametro>> ObtenerEspeciesParametros(int id)
        {
            return await _context.Especies_Reporte
                                 .Include(e => e.idEspecie)
                                 .Where(d => d.idParametro == id)
                                 .ToListAsync();
        }

        public async Task<List<Ubicaciones_Parametro>> ObtenerUbicacionesParametros(int id)
        {
            return await _context.Ubicaciones_Reporte
                                 .Include(e => e.idUbicacion)
                                 .Where(d => d.idParametro == id)
                                 .ToListAsync();
        }

        public async Task<List<Reporte>> ObtenerTodas()
        {
            return await _context.Reportes
                                 .Include(e => e.parametros)
                                 .Include(e => e.destinatarios)
                                 .Include(e => e.tipoFrecuencia)
                                 .ToListAsync();
        }

        public async Task<Reporte> ObtenerPorId(int id)
        {
            return await _context.Reportes
                                 .Include(e => e.parametros)
                                 .Include(e => e.destinatarios)
                                 .Include(e => e.tipoFrecuencia)
                                 .FirstOrDefaultAsync(e => e.idReporte == id);
        }

        public async Task Agregar(Reporte reporte)
        {
            _context.Reportes.Add(reporte);
            await _context.SaveChangesAsync();
        }

        public async Task AgregarDestinatario(Destinatario destinatario)
        {
            _context.Destinatarios.Add(destinatario);
            await _context.SaveChangesAsync();
        }

        public async Task AgregarEspecies(Especies_Parametro parametro)
        {
            _context.Especies_Reporte.Add(parametro);
            await _context.SaveChangesAsync();
        }

        public async Task AgregarUbicaciones(Ubicaciones_Parametro parametro)
        {
            _context.Ubicaciones_Reporte.Add(parametro);
            await _context.SaveChangesAsync();
        }

        public async Task AgregarParametro(Parametro parametro)
        {
            _context.Parametros.Add(parametro);
            await _context.SaveChangesAsync();
        }

        public async Task Actualizar(Reporte reporte)
        {
            _context.Entry(reporte).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Eliminar(int id)
        {
            var reporte = await _context.Reportes.FindAsync(id);
            if (reporte != null)
            {
                _context.Reportes.Remove(reporte);
                await _context.SaveChangesAsync();
            }
        }
    }
}
