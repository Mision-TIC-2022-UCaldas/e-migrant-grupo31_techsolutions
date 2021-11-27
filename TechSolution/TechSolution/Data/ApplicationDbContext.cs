using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TechSolution.Models;

namespace TechSolution.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
       public DbSet<Migrante> Migrantes { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
