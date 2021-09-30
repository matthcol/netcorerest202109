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
                    Color = WineColor.ROSE,
                    Vintage = 2020
                };
                var two = new Wine
                {
                    Id = 2,
                    Appellation = "Nuit Saint Georges",
                    Color = WineColor.ROUGE,
                    Vintage = 2016
                };
                var three = new Wine
                {
                    Id = 3,
                    Appellation = "Pommard",
                    Color = WineColor.ROUGE,
                    Vintage = 2000,
                };

                var drinker1 = new Drinker
                {
                    Name = "Matthias",
                    PreferredWine = two,
                    PreferredWineId = two.Id
                };

                var drinker2 = new Drinker
                {
                    Name = "Olivier",
                    PreferredWine = three,
                    PreferredWineId = three.Id
                };

                context.AddRange(one, two, three,
                    drinker1, drinker2);
                context.SaveChanges();
            }
        }
    }
}
