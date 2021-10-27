using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.DataContext
{
    public class context : DbContext
    {
        public context(DbContextOptions options) : base(options)
        {
            
    }
        public DbSet<user> users { get; set; }

    }
}
