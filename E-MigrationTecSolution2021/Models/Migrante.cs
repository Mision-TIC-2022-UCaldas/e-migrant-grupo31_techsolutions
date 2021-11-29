using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_MigrationTecSolution2021.Models
{
    public class Migrante
    {
        [Key]
        [Required]
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
        [Range(1920,2021)]
        public string AñoNacimiento { get; set; }
        [Required]
        [Range(1, 12)]
        public string MesNacimiento { get; set; }
        [Required]
        [Range(1, 30)]
        public string DiaNacimiento { get; set; }
        public string CorreoElectronico { get; set; }
        public int NTel { get; set; }
        public string DireccionActual { get; set; }
        public string Ciudad { get; set; }
        public string SituacionLaboral { get; set; }
        public RegistroNec RegistroNec { get; set; }
    }
}
