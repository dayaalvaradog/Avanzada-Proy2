using Core.Entidades;
using DataAccess.Data;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.AccesoDatos
{
    public class SemillaAD : ISemilla
    {
        private readonly ApplicationDbContext _context;

        public SemillaAD(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Semilla>> ObtenerTodas()
        {
            return await _context.Semillas
                                 .Include(e => e.especie)
                                 .Include(e => e.ubicacion)
                                 .ToListAsync();
        }

        public async Task<Semilla> ObtenerPorId(int id)
        {
            return await _context.Semillas
                                 .Include(e => e.especie)
                                 .Include(e => e.ubicacion)
                                 .FirstOrDefaultAsync(e => e.idSemilla == id);
        }

        public async Task Agregar(Semilla semilla)
        {
            _context.Semillas.Add(semilla);
            await _context.SaveChangesAsync();
        }

        public async Task Actualizar(Semilla semilla)
        {
            _context.Entry(semilla).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Eliminar(int id)
        {
            var semilla = await _context.Semillas.FindAsync(id);
            if (semilla != null)
            {
                _context.Semillas.Remove(semilla);
                await _context.SaveChangesAsync();
            }
        }
    }

}
