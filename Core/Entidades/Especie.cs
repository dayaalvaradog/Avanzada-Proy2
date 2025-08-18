using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int idEspecie { get; set; }
        public string nombreCientifico { get; set; }
        public string nombreComun { get; set; }

        [BindRequired]
        public int idFamilia { get; set; }

        [ForeignKey("idFamilia")]
        [ValidateNever]
        public Familia familia { get; set; }

        public string descripcion { get; set; }
    }
}
