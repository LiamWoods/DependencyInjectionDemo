using Microsoft.AspNetCore.Mvc;

namespace SimpleInjectorDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewController : ControllerBase
    {
        private readonly IConcreteService _service;

        public NewController(IConcreteService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetTheThing()
        {
            var someValue = _service.DoSomething();
            return Ok(someValue);
        }
    }
}
