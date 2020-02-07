using DependencyInjectionDemo.Injection;
using DependencyInjectionDemo.Utils;
using DependencyInjectionDemo.Utils.FactoryItems;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System.Threading.Tasks;
using Xunit;

namespace DependencyInjectionTests
{
    public class GoodControllerTests
    {
        [Fact]
        public async Task Get_Returns_AFreshCake()
        {
            // Control over expected cake
            // Ignore internal logic/dependencies of any ICakeFactory Implementation
            var expectedCake = new Cake { Style = CakeStyle.ChocolateFudge, IsFresh = true };
            var cakeMock = Substitute.For<ICakeFactory>();
            cakeMock
                .Bake(0)
                .ReturnsForAnyArgs(expectedCake);

            var sut = new GoodController(cakeMock);

            var result = await sut.Get();

            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var cake = okObjectResult.Value as Cake;
            Assert.NotNull(cake);

            Assert.True(cake.IsFresh);
        }
    }
}
