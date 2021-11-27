using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechSolution.Models
{
    public class Migrante
    {
        [Key]

        public int NId { get; set; }   
        [Required]
        public string TId { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellidos { get; set; }
        [Required]
        public string Pais { get; set; }
        [Required]
        public string FechaNacimiento { get; set; }
        public string CorreoElectronico { get; set; }
        public int NTel { get; set; }
        public string DireccionActual { get; set; }
        public string Ciudad { get; set; }
        public string SituacionLaboral { get; set; }

    }
}
