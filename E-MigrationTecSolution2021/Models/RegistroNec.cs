using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_MigrationTecSolution2021.Models
{
    public class RegistroNec
    {
        [Key]
        public string Nit { get; set; }
        [Required]

        public string Descripcion { get; set; }
        [Required]
        public string prioridad { get; set; }
        [Required]
        public string categoria { get; set; }
        [Required]
        public string Estado { get; set; }
    }
}
