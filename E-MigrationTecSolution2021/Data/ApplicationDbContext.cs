using E_MigrationTecSolution2021.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_MigrationTecSolution2021.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<OfServicio> OfServicios { get; set; }
        public DbSet<Migrante> Migrantes { get; set; }
        public DbSet<Entidad> Entidades { get; set; }
       


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<E_MigrationTecSolution2021.Models.OfServicio> OfServicio { get; set; }
    }
}
