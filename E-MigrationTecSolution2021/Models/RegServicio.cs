using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_MigrationTecSolution2021.Models
{
    public class RegServicio
    {
        [Key]
        [Required]
        public virtual string NDocumento { get; set; }
        [Required]
        public  string NombreDelServicio { get; set; }


    }
}
