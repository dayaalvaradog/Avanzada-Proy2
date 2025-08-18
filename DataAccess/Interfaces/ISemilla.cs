using Core.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces
{
    public interface ISemilla
    {
        Task<List<Semilla>> ObtenerTodas();
        Task<Semilla> ObtenerPorId(int id);
        Task Agregar(Semilla semilla);
        Task Actualizar(Semilla semilla);
        Task Eliminar(int id);
    }
}
