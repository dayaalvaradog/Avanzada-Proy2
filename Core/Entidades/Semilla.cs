using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entidades
{
    public class Semilla
    {
        /// <summary>
        /// Representa una semilla almacenada en el sistema.
        /// </summary>

        public int idSemilla { get; set; }
        public string nombre { get; set; }
        public Especie especie { get; set; }
        public Ubicacion ubicacion { get; set; }
        public int cantidad { get; set; }
        public DateTime fechaAlmacenamiento { get; set; }
    }
}
