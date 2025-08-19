using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        
        public int idParametro { get; set; }
        public DateTime? fechaDesde { get; set; }
        public DateTime? fechaHasta { get; set; }
        [NotMapped] 
        public List<Especie>? especies { get; set; }
        [NotMapped]
        public List<Ubicacion>? ubicaciones { get; set; }

    }
}
