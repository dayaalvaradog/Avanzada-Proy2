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
    public class Semilla
    {
        /// <summary>
        /// Representa una semilla almacenada en el sistema.
        /// </summary>

        public int idSemilla { get; set; }
        public string nombre { get; set; }

        [BindRequired]
        public int idEspecie { get; set; }

        [ForeignKey("idEspecie")]
        [ValidateNever]
        public Especie especie { get; set; }
        
        [BindRequired]
        public int idUbicacion { get; set; }
        
        [ForeignKey("idUbicacion")]
        [ValidateNever]
        public Ubicacion ubicacion { get; set; }
        public int cantidad { get; set; }
        public DateTime fechaAlmacenamiento { get; set; }
    }
}
