using DependencyInjectionDemo.Utils;
using DependencyInjectionDemo.Utils.FactoryItems;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DependencyInjectionDemo.NoInjection
{
    [ApiController]
    [Route("[controller]")]
    public class BadController : ControllerBase
    {
        private readonly ICakeFactory _cakeFactory;

        public BadController()
        {
            _cakeFactory = new WarehouseCakeFactory();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var cake = await _cakeFactory.Bake(CakeStyle.ChocolateFudge);
            return Ok(cake);
        }
    }
}
