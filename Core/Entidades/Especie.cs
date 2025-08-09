using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entidades
{
    /// <summary>
    /// Representa una especie de planta almacenada en el sistema.
    /// </summary>
    public class Especie
    {
        int idEspecie { get; set; }
        string nombreCientifico { get; set; }
        string nombreComun { get; set; }
        Familia familia { get; set; }
        string descripcion { get; set; }
    }
}
