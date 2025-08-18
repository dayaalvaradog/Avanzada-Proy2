using Core.Entidades;
using DataAccess.Data;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.AccesoDatos
{
    public class UbicacionAD : IUbicacion
    {
        private readonly ApplicationDbContext _context;

        public UbicacionAD(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Agregar(Ubicacion ubicacion)
        {
            _context.Ubicaciones.Add(ubicacion);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Ubicacion>> ObtenerTodas() => await _context.Ubicaciones.ToListAsync();

        public async Task<Ubicacion> ObtenerPorId(int id) => await _context.Ubicaciones.FindAsync(id);
    }
}
