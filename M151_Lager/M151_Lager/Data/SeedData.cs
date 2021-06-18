using M151_Lager.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M151_Lager.Data
{
    public static class SeedData
    {
        private static DataContext _context;
        public static void EnsureDbCreatedAndSeeded(this DataContext context)
        {
            _context = context;
            context.Database.Migrate();
            context.SaveChanges();
        }
     
    }
}