using DependencyInjectionDemo.Utils;
using DependencyInjectionDemo.Utils.FactoryItems;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionDemo.FactoryInjection
{
    [ApiController]
    [Route("[controller]")]
    public class ExternalCakeController : ControllerBase
    {
        private readonly ICakeFactory _cakeFactory;

        public ExternalCakeController(ExternalCakeFactory cakeFactory)
        {
            _cakeFactory = cakeFactory;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var cake = _cakeFactory.Bake(CakeStyle.ChocolateFudge);
            return Ok(cake);
        }
    }
}