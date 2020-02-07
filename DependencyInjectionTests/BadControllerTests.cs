using System;
using System.Threading.Tasks;
using DependencyInjectionDemo.NoInjection;
using DependencyInjectionDemo.Utils;
using DependencyInjectionDemo.Utils.FactoryItems;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Xunit;

namespace DependencyInjectionTests
{
    public class BadControllerTests
    {
        [Fact]
        public async Task Get_Returns_AFreshCake()
        {
            var sut = new BadController();

            // BadController always uses a WarehouseCakeFactory
            // No control over cake creation
            // Nasty stale cakes

            var result = await sut.Get();

            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var cake = okObjectResult.Value as Cake;
            Assert.NotNull(cake);

            Assert.True(cake.IsFresh);
        }
    }
}
