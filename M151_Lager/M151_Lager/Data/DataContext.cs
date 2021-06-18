using M151_Lager.Modell;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M151_Lager.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Benutzer> Benutzer { get; set; }
        public DbSet<Grafikkarte> Grafikkarte { get; set; }
        public DbSet<Kauf> Kauf { get; set; }
        public DbSet<Preis> Preis{get; set; }
    }
}