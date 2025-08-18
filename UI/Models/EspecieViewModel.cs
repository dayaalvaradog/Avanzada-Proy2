using Core.Entidades;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace UI.Models
{
    public class EspecieViewModel
    {
        public int? idEspecie { get; set; } = 0;
        public string nombreCientifico { get; set; }
        public string nombreComun { get; set; }
        public string descripcion { get; set; }
        public int? idFamilia { get; set; }

        public List<Familia> familias { get; set; } = new List<Familia>();
    }
}
