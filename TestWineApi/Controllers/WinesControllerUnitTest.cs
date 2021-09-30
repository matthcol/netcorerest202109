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
using WineApiRest.Services;
using WineApiRestDbr.Controllers;
using Xunit;

namespace TestWineApi.Controllers
{
    public class WinesControllerUnitTest 
    {
        private readonly Mock<ILogger<WinesController>> _mockLogger;

        public WinesControllerUnitTest()          
        {
            _mockLogger = new Mock<ILogger<WinesController>>();
        }

        [Fact]
        public async void test_GetWine_absent()
        {
            var id = (uint)0;
            var mockWineService = new Mock<IWineService>();
            mockWineService.Setup(s => s.GetWine(id))
                .ReturnsAsync((Wine) null)
                .Verifiable(); 

            var wineController = new WinesController(mockWineService.Object, null, _mockLogger.Object);
            

            var actionResult = await wineController.GetWine(id);

            Assert.IsType<NotFoundResult>(actionResult.Result);
            Assert.Null(actionResult.Value);
            // Assert.Equal(404, ((NotFoundResult) actionResult.Result).StatusCode);

            // check if service mocked has been called
            mockWineService.Verify();
        }

        [Fact]
        public async void test_GetWine_present()
        {
            // arrange
            var id = (uint)1;
            var mockWineService = new Mock<IWineService>();
            mockWineService.Setup(s => s.GetWine(id))
               .ReturnsAsync(new Wine 
               {
                   Id = id,
                   Appellation = "Nuit Saint Georges"
               })
               .Verifiable();
            var wineController = new WinesController(mockWineService.Object, null, _mockLogger.Object);
            
            // when
            var actionResult = await wineController.GetWine(id);

            // Then
            Assert.Null(actionResult.Result);
            Assert.NotNull(actionResult.Value);
            // Assert.IsType<Wine>(actionResult.Value); // done by typing
            Assert.Equal(id, actionResult.Value.Id);

            // Verify
            mockWineService.Verify();
        }
    }
}
