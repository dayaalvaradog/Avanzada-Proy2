using Core.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces
{
    public interface IEspecie
    {
        Task<List<Especie>> ObtenerTodas();
        Task<Especie> ObtenerPorId(int id);
        Task Agregar(Especie especie);
        Task Actualizar(Especie especie);
        Task Eliminar(int id);
    }

}
