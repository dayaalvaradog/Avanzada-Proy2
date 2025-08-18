using Core.Entidades;
using DataAccess.Data;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.AccesoDatos
{
    public class EspecieAD : IEspecie
    {
        private readonly ApplicationDbContext _context;

        public EspecieAD(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Especie>> ObtenerTodas()
        {
            return await _context.Especies
                                 .Include(e => e.familia)
                                 .ToListAsync();
        }

        public async Task<Especie> ObtenerPorId(int id)
        {
            return await _context.Especies
                                 .Include(e => e.familia)
                                 .FirstOrDefaultAsync(e => e.idEspecie == id);
        }

        public async Task Agregar(Especie especie)
        {
            _context.Especies.Add(especie);
            await _context.SaveChangesAsync();
        }

        public async Task Actualizar(Especie especie)
        {
            _context.Entry(especie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Eliminar(int id)
        {
            var especie = await _context.Especies.FindAsync(id);
            if (especie != null)
            {
                _context.Especies.Remove(especie);
                await _context.SaveChangesAsync();
            }
        }
    }

}
