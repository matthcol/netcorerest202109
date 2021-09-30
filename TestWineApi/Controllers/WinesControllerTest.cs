using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWineApi.Model;
using WineApiRest.Model;
using WineApiRestDbr.Controllers;
using Xunit;

namespace TestWineApi.Controllers
{
    public class WinesControllerTest: WineDbTest
    {
        public WinesControllerTest():
            base(new DbContextOptionsBuilder<WineDbContext>()
                .UseInMemoryDatabase("WineDbTestC")
                .Options)
        { }

        [Fact]
        public void test_GetWine_present()
        {
            using (var context = new WineDbContext(ContextOptions))
            {
                ILogger<WinesController> logger = null;
                var wineController = new WinesController(context, logger);
            }
        }
    }
}
