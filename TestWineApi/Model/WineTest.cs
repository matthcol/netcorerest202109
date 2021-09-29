using System;
using WineApiRest.Model;
using Xunit;

namespace TestWineApi
{
    public class WineTest
    {
        [Fact]
        public void TestConstructor()
        {
            var appellation = "Nuit Saint Georges";
            var wine = new Wine
            {
                Appellation = appellation
            };
            Assert.NotNull(wine.Appellation);
            Assert.Equal(appellation, wine.Appellation);
            Assert.Null(wine.Id);
        }

        [Theory]
        [InlineData(WineColor.ROSE)]
        [InlineData(WineColor.ROUGE)]
        [InlineData(WineColor.BLANC)]
        public void TestConstructor_Color(WineColor color) 
        {
            var wine = new Wine
            {
                Appellation = "Nuit Saint Georges",
                Color = color
            };
            Assert.Equal(wine.Color, color);
        }

    }
}
