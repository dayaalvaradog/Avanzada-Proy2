using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entidades
{
    public class Reporte
    {
        public int idReporte { get; set; }
        public string nombreReporte { get; set; }
        public int cantFrecuencia { get; set; }
        public int diaInicio { get; set; }
        public int? diaFin { get; set; }
        public int hora { get; set; }
        public int minuto { get; set; }
        public bool activo { get; set; }
        public int idTipoFrecuencia { get; set; }
        public int idParametro { get; set; }
        public int idUsuario { get; set; }

        public TipoFrecuencia tipoFrecuencia { get; set; }
        public Parametro parametros { get; set; }
        public List<Destinatario> destinatarios { get; set; }
        public string proximoEnvio { get; set; }

    }
}
