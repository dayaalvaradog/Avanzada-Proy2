using Core.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces
{
    public interface IFamilia
    {
        Task Agregar(Familia familia);
        Task<List<Familia>> ObtenerTodas();
        Task<Familia> ObtenerPorId(int id);
    }
}
