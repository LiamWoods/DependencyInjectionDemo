using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionDemo.InheritanceOverFactory
{
    [Route("[controller]")]
    [ApiController]
    public class NewController : ControllerBase
    {
        private readonly IRepo<NewConfig> _repo;

        public NewController(IRepo<NewConfig> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetSomething();
            return Ok(result);
        }
    }
}