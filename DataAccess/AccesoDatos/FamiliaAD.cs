using Core.Entidades;
using DataAccess.Data;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.AccesoDatos
{
    public  class FamiliaAD : IFamilia
    {
        private readonly ApplicationDbContext _context;

        public FamiliaAD(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Agregar(Familia familia)
        {
            _context.Familias.Add(familia);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Familia>> ObtenerTodas() => await _context.Familias.ToListAsync();

        public async Task<Familia> ObtenerPorId(int id) => await _context.Familias.FindAsync(id);
    }
}
