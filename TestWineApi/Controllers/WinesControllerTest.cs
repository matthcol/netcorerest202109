using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
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
        private readonly Mock<ILogger<WinesController>> _mockLogger;

        public WinesControllerTest():
            base(new DbContextOptionsBuilder<WineDbContext>()
                .UseInMemoryDatabase("WineDbTestC")
                .Options)
        {
            _mockLogger = new Mock<ILogger<WinesController>>();
        }

        [Fact]
        public async void test_GetWine_absent()
        {
            using (var context = new WineDbContext(ContextOptions))
            {
                ILogger<WinesController> logger = null;
                var wineController = new WinesController(context, _mockLogger.Object);
                var id = (uint) 0;
                
                var actionResult = await wineController.GetWine(id);

                Assert.IsType<NotFoundResult>(actionResult.Result);
                Assert.Null(actionResult.Value);
                // Assert.Equal(404, ((NotFoundResult) actionResult.Result).StatusCode);

            }
        }

        [Fact]
        public async void test_GetWine_present()
        {
            using (var context = new WineDbContext(ContextOptions))
            {
                var wineController = new WinesController(context, _mockLogger.Object);
                var id = (uint)1;

                var actionResult = await wineController.GetWine(id);

                Assert.Null(actionResult.Result);
                Assert.NotNull(actionResult.Value);
                // Assert.IsType<Wine>(actionResult.Value); // done by typing
                Assert.Equal(id, actionResult.Value.Id);

            }
        }
    }
}
