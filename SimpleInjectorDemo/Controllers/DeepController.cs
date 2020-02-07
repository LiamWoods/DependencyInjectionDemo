using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SimpleInjectorDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeepController : ControllerBase
    {
        private readonly DeepService service;

        public DeepController(DeepService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = service.GetBool();
            return Ok(result);
        }
    }

    public class DeepService
    {
        private readonly DeeperService service;

        public DeepService(DeeperService service)
        {
            this.service = service;
        }

        public bool GetBool()
        {
            return service.GetBool();
        }
    }

    public class DeeperService
    {
        private readonly DeepestService service;

        public DeeperService(DeepestService service)
        {
            this.service = service;
        }

        public bool GetBool()
        {
            return service.GetBool();
        }
    }

    public class DeepestService
    {
        private readonly IDeeeeeepDependency dependency;

        public DeepestService(IDeeeeeepDependency dependency)
        {
            this.dependency = dependency;
        }

        public bool GetBool()
        {
            return dependency.GetBool();
        }
    }

    public interface IDeeeeeepDependency
    {
        bool GetBool();
    }

    public class DeeeeeepDependency : IDeeeeeepDependency
    {
        public bool GetBool()
        {
            return false;
        }
    }
}