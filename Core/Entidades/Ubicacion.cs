using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entidades
{
    public class Ubicacion
    {
        /// <summary>
        /// Ubicaciones de almacenamiento de semillas.
        /// </summary>

        public int idUbicacion { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string condicionesAlmacenamiento { get; set; }
    }
}
