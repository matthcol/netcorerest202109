using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WineApiRest.Model
{
    public class WineDbContext: DbContext
    {
        public WineDbContext(DbContextOptions<WineDbContext> options)
            : base(options)
        {

        }

        public DbSet<Wine> Wines { get; set; }
    }
}
