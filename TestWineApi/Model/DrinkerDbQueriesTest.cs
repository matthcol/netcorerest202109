using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineApiRest.Model;
using Xunit;

namespace TestWineApi.Model
{
    public class DrinkerDbQueriesTest : WineDbTest
    {
        public DrinkerDbQueriesTest() :
            base(new DbContextOptionsBuilder<WineDbContext>()
                .UseInMemoryDatabase("WineDbTest2")
                .Options)
        {
        }

        [Fact]
        public void test_query_all()
        {
            using (var context = new WineDbContext(ContextOptions))
            {
                var drinkers = context.Drinkers
                    .Include("PreferredWine")
                    .ToList();
            }
        }

        [Fact]
        public void test_query_byPreferredWineColor()
        {
            using (var context = new WineDbContext(ContextOptions))
            {
                var color = WineColor.ROUGE;
                var res = context.Drinkers
                    .Where(d => d.PreferredWine.Color == color)
                    .ToList();
            }
        }
    }
}
