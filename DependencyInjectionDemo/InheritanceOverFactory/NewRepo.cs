using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionDemo.InheritanceOverFactory
{
    public class NewRepo : RepoBase<NewConfig>
    {
        public NewRepo(IOptions<NewConfig> config) : base(config) { }

        public override string GetSomething()
        {
            return base.GetSomething();
        }
    }
}
