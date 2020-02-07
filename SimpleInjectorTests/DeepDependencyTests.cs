using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using SimpleInjector;
using SimpleInjectorDemo.Controllers;
using Xunit;

namespace SimpleInjectorTests
{
    public class DeepDependencyTests
    {
        private readonly Container _container;
        public DeepDependencyTests()
        {
            _container = new Container();
            _container.Options.ResolveUnregisteredConcreteTypes = true;
        }

        [Fact]
        public void DeeeeeepDependencyCanBeMocked()
        {
            var deeeeepDependencyMock = Substitute.For<IDeeeeeepDependency>();
            deeeeepDependencyMock.GetBool().ReturnsForAnyArgs(true);
            _container.RegisterInstance(deeeeepDependencyMock);

            var sut = _container.GetInstance<DeepController>();
            var result = sut.Get();
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.True((bool)okObjectResult.Value);
        }
    }
}
