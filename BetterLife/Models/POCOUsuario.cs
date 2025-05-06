using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BetterLife.Models
{
    public class Usuario
    {
        [Key]
        public int id_Usuario { get; set; }
        
        public string Nombre_Usuario { get; set; }
        public string Apellidos_Usuario { get; set; }
        public byte Edad_Usuario { get; set; }
        public string Genero_Usuario { get; set; }
        public string Estatura { get; set; }
        public byte Peso_Usuario { get; set; }
        public string BrazoRelajado { get; set; }
        public string BrazoContraido { get; set; }
        public string Cintura { get; set; }
        public string Pierna { get; set; }

        public virtual ICollection<Rutinas> Rutinas { get; set; }
    }

}