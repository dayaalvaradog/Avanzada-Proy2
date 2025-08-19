using Core.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces
{
    public interface IReporte
    {
        Task<List<TipoFrecuencia>> ObtenerTipoFrecuencia();
        Task<List<Destinatario>> ObtenerDestinatarios(int id);
        Task<Parametro> ObtenerParametros(int id);
        Task<List<Ubicaciones_Parametro>> ObtenerUbicacionesParametros(int id);
        Task<List<Especies_Parametro>> ObtenerEspeciesParametros(int id);
        Task<List<Reporte>> ObtenerTodas();
        Task<Reporte> ObtenerPorId(int id);
        Task Agregar(Reporte reporte);
        Task AgregarEspecies(Especies_Parametro parametro);
        Task AgregarUbicaciones(Ubicaciones_Parametro parametro);
        Task AgregarDestinatario(Destinatario destinatario);
        Task Actualizar(Reporte reporte);
        Task Eliminar(int id);
    }
}
