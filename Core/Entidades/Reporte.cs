using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entidades
{
    public class Reporte
    {
        string id { get; set; }
        string nombreReporte { get; set; }
        public int cantFrecuencia { get; set; }
        public TipoFrecuencia tipoFrecuencia { get; set; }
        public Parametro parametros { get; set; }
        public List<Destinatario> destinatarios { get; set; }
        string proximoEnvio { get; set; }

    }
}
