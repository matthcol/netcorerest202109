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
            Assert.Equal(appellation, wine.Appellation);
        }
    }
}
