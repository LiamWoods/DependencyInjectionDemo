using DependencyInjectionDemo.Utils;
using DependencyInjectionDemo.Utils.FactoryItems;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionDemo.FactoryInjection
{
    [ApiController]
    [Route("[controller]")]
    public class StaleController : ControllerBase
    {
        private readonly ICakeFactory _cakeFactory;

        public StaleController(CakeFactoryFactory cakeFactoryFactory)
        {
            _cakeFactory = cakeFactoryFactory.GetFactory("stale");
        }

        [HttpGet]
        public IActionResult Get()
        {
            var cake = _cakeFactory.Bake(CakeStyle.ChocolateFudge);
            return Ok(cake);
        }
    }
}
