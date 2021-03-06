using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineApiRest.Dto;
using WineApiRest.Model;
using Xunit;

namespace TestWineApi.Model
{
    public class WineDbQueriesTest : WineDbTest
    {
        public WineDbQueriesTest() :
            base(new DbContextOptionsBuilder<WineDbContext>()
                .UseInMemoryDatabase("WineDbTest")
                .Options)
        {
        }

        [Fact]
        public void test_query_all()
        {
            using (var context = new WineDbContext(ContextOptions))
            {
                var wines = context.Wines.ToList();
                Assert.Equal(3, wines.Count);
            }
        }

        [Fact]
        public void test_query_byVintage()
        {
            using (var context = new WineDbContext(ContextOptions))
            {
                // arrange
                var vintage = (short)2000;
                // add a wine from this vintage
                context.Add(new Wine
                {
                    Appellation = "Saint Emilion",
                    Vintage = vintage
                });
                context.SaveChanges();
                // when
                var wines = context.Wines
                    .Where(w => w.Vintage == vintage)
                    .ToList();
                // Cheat: in order to fail this test
                // wines[0].Vintage = 2021;
                // wines[1].Vintage = 2010;
                // verify
                Assert.Equal(2, wines.Count);
                Assert.All(wines, w => Assert.Equal(vintage, w.Vintage));
            }
        }

        [Fact]
        public void test_query_byVintageRange()
        {
            using (var context = new WineDbContext(ContextOptions))
            {

                var vintageStart = (short)1995;
                var vintageEnd = (short)2018;
                var query = from w in context.Wines
                            where w.Vintage >= vintageStart
                                && w.Vintage <= vintageEnd
                            orderby w.Vintage
                            select w;
                var wines = query.ToList();
                // Cheat
                // wines[0].Vintage = null;
                Assert.Equal(2, wines.Count);
                Assert.All(wines,
                    w =>
                    {
                        Assert.NotNull(w.Vintage);
                        Assert.InRange(Convert.ToInt16(w.Vintage), vintageStart, vintageEnd);
                    });
            }
        }

        [Fact]
        public void test_query_projection1field()
        {
            using (var context = new WineDbContext(ContextOptions))
            {
                var word = "Pom";
                // projection sur la colonne Appelation de type string
                // résultat dans List<string>
                var wineAppellations = context.Wines
                    .Where(w => w.Appellation.StartsWith(word))
                    .Select(w => w.Appellation)
                    .ToList();
            }
        }

        [Fact]
        public void test_query_projection2fields_anonymousDto()
        {
            using (var context = new WineDbContext(ContextOptions))
            {
                // select Appellation, Couleur from Wines
                var res = context.Wines
                    .Select(w => new
                        {
                            Appellation = w.Appellation,
                            Color = w.Color
                        })
                    .ToList();        
            }
        }

        [Fact]
        public void test_query_projection2fields_Dto()
        {
            using (var context = new WineDbContext(ContextOptions))
            {
                // select Appellation, Couleur from Wines
                var res = context.Wines
                    .Select(w => new AppellationColor
                        {
                            Appellation = w.Appellation,
                            Color = w.Color
                        })
                    .ToList();
            }
        }

        [Fact]
        public void test_query_groupby()
        {
            using (var context = new WineDbContext(ContextOptions))
            {
                context.AddRange(
                    new Wine
                    {
                        Appellation = "Saint Emilion",
                        Color = WineColor.ROUGE,
                        Vintage = 1948
                    }, 
                    new Wine
                    {
                        Appellation = "Jurançon",
                        Color = WineColor.BLANC,
                        Vintage = 2015
                    }
                );
                context.SaveChanges();
                var res = context.Wines
                    .GroupBy(
                        w => w.Color, // key groupby
                        w => w.Vintage, // property for computings statistics
                        (color, vintages) => new
                        {
                            Color = color,
                            Count = vintages.Count(),
                            VintageMin = vintages.Min(),
                            VintageMax = vintages.Max()
                        })
                    .ToList();
            }
        }

    }
}