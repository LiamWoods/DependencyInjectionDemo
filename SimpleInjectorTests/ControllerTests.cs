using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using SimpleInjector;
using SimpleInjectorDemo;
using SimpleInjectorDemo.Controllers;
using Xunit;

namespace SimpleInjectorTests
{
    public class ControllerTests
    {
        private Container _container;
        public ControllerTests()
        {
            _container = new Container();
            _container.Options.ResolveUnregisteredConcreteTypes = true;
        }

        [Fact]
        public void NewController_GetsTheThing()
        {
            var substitute = Substitute.For<IConcreteService>();
            substitute
                .DoSomething()
                .ReturnsForAnyArgs(true);
            _container.RegisterInstance(substitute);

            var sut = _container.GetInstance<NewController>();

            var result = sut.GetTheThing();
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.True((bool)okObjectResult.Value);
        }

        [Fact]
        public void OldController_GetsTheThing()
        {
            var sut = _container.GetInstance<OldController>();

            var result = sut.GetTheThing();
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.True((bool)okObjectResult.Value);
        }
    }
}
