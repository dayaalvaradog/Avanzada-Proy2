using Core.Entidades;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace UI.Models
{
    public class SemillaViewModel
    {
        public int? idSemilla { get; set; }
        public string nombre { get; set; }
        public int idEspecie { get; set; }
        public int idUbicacion { get; set; }
        public int cantidad { get; set; }
        public DateTime fechaAlmacenamiento { get; set; }

        public List<Especie> especies { get; set; } = new List<Especie>();
        public List<Ubicacion> ubicaciones { get; set; } = new List<Ubicacion>();
    }
}
