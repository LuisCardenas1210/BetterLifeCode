using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BetterLife.Models
{
    public class Rutinas
    {
        [Key]
        public int id_Rutina { get; set; }

        [Required]
        public string Rutina{ get; set; }

        public int? id_Usuario { get; set; }
        public int? id_Profesional { get; set; }

        [ForeignKey("id_Usuario")]
        public virtual Usuario Usuario { get; set; }
        [ForeignKey("id_Profesional")]
        public virtual Profesional Profesional { get; set; }
    }

}