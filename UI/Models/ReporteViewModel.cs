using Core.Entidades;
using System.Collections.Generic;

namespace UI.Models
{
    public class ReporteViewModel
    {
        public Reporte Reporte { get; set; }
        public List<TipoFrecuencia> TiposFrecuencia { get; set; } = new List<TipoFrecuencia>();
        public List<Especie> Especies { get; set; } = new List<Especie>();
        public List<Ubicacion> Ubicaciones { get; set; } = new List<Ubicacion>();
        public List<Destinatario> Destinatarios { get; set; } = new List<Destinatario>();
    }
}
