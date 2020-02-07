using DependencyInjectionDemo.Utils;
using DependencyInjectionDemo.Utils.FactoryItems;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionDemo.FactoryInjection
{
    [ApiController]
    [Route("[controller]")]
    public class FreshController : ControllerBase
    {
        private readonly ICakeFactory _cakeFactory;

        public FreshController(CakeFactoryFactory cakeFactoryFactory)
        {
            _cakeFactory = cakeFactoryFactory.GetFactory("fresh");
        }

        [HttpGet]
        public IActionResult Get()
        {
            var cake = _cakeFactory.Bake(CakeStyle.ChocolateFudge);
            return Ok(cake);
        }
    }
}
