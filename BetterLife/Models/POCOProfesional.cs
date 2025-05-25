using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BetterLife.Models
{
    public class Profesional
    {
        [Key]
        public int id_Profesional { get; set; }
        public string Nombre_Profesional { get; set; }
        public string Apellido_Profesional { get; set; }
        public string Genero_Profesional { get; set; }
        public string NivelEstudio { get; set; }
        public string Titulo { get; set; }
        public string TipoProfesional { get; set; }
        public string email { get; set; }
        public string email2 { get; set; }
        public string telefono { get; set; }
        public string telefono2 { get; set; }

        public virtual ICollection<Rutinas> Rutinas { get; set; }
    }

}