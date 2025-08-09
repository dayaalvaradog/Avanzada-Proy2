using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entidades
{
    public class Parametro
    {
        /// <summary>
        /// Representa un parámetro de configuración del reporte.
        /// </summary>
        
        public DateTime? fechaDesde { get; set; }
        public DateTime? fechaHasta { get; set; }
        public List<Especie>? especies { get; set; }
        public List<Ubicacion>? ubicaciones { get; set; }

    }
}
