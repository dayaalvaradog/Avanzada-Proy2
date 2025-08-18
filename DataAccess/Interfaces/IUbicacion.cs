using Core.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces
{
    public interface IUbicacion
    {
        Task Agregar(Ubicacion ubicacion);
        Task<List<Ubicacion>> ObtenerTodas();
        Task<Ubicacion> ObtenerPorId(int id);
    }
}
