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
    public class WineDbQueriesTest: WineDbTest 
    {
        public WineDbQueriesTest() :
            base(new DbContextOptionsBuilder<WineDbContext>()
                .UseInMemoryDatabase("WineDbTest")
                .Options)
        { 
        }

        [Fact]
        public void test_query_find()
        {
            using (var context = new WineDbContext(ContextOptions))
            {
                var wines = context.Wines.ToList();
                Assert.Equal(3, wines.Count);
            }
        }

        [Fact]
        public void test_query_byMillesime()
        {
            // _context.Wines.Find()
        }
    }
}
