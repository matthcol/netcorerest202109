using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineApiRest.Model;

namespace TestWineApi.Model
{
    // classe commune à tous les tests avec contexte de base de données
    public class WineDbTest
    {
        protected WineDbTest(DbContextOptions<WineDbContext> contextOptions)
        {
            ContextOptions = contextOptions;

            Seed();
        }

        protected DbContextOptions<WineDbContext> ContextOptions { get; }

        private void Seed()
        {
            using (var context = new WineDbContext(ContextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var one = new Wine
                {
                    Id = 1,
                    Appellation = "Beaujolais",
                    Vintage = 2020
                };
                var two = new Wine
                {
                    Id = 2,
                    Appellation = "Nuit Saint Georges",
                    Vintage = 2016
                };
                var three = new Wine
                {
                    Id = 3,
                    Appellation = "Pommard",
                    Vintage = 2000
                };

                context.AddRange(one, two, three);

                context.SaveChanges();
            }
        }
    }
}
