using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_MigrationTecSolution2021.Models
{
    public class Entidad
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string RazonSocial { get; set; }
        [Required]
        public int Nit { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string Ciudad { get; set; }
        [Required]
        public string Telefono { get; set; }
        
        public string Correo { get; set; }
        [Required]
        public string Paginaweb { get; set; }
        [Required]
        public Sector Sector  { get; set; }
        [Required]
        public TipoServicio TipoServicio { get; set; }


    }
}
