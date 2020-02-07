using Microsoft.AspNetCore.Mvc;

namespace SimpleInjectorDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OldController : ControllerBase
    {
        private readonly ConcreteService _service;

        public OldController()
        {
            _service = new ConcreteService();
        }

        [HttpGet]
        public IActionResult GetTheThing()
        {
            var someValue = _service.DoSomething();
            return Ok(someValue);
        }
    }
}
