using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineApiRest.Model;

namespace TestWineApi.Model
{
    public class DrinkerDbQueriesTest: WineDbTest
    {
        public DrinkerDbQueriesTest():
            base(new DbContextOptionsBuilder<WineDbContext>()
                .UseInMemoryDatabase("WineDbTest")
                .Options)
        {
        }
    }
}
