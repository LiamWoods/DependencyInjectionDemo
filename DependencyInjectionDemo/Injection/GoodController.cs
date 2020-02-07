using DependencyInjectionDemo.Utils;
using DependencyInjectionDemo.Utils.FactoryItems;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DependencyInjectionDemo.Injection
{
    [ApiController]
    [Route("[controller]")]
    public class GoodController : ControllerBase
    {
        private readonly ICakeFactory _cakeFactory;

        public GoodController(ICakeFactory cakeFactory)
        {
            _cakeFactory = cakeFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var cake = await _cakeFactory.Bake(CakeStyle.ChocolateFudge);
            return Ok(cake);
        }
    }
}
