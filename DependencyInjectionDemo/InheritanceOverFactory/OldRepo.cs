using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionDemo.InheritanceOverFactory
{
    public class OldRepo : RepoBase<OldConfig>
    {
        public OldRepo(IOptions<OldConfig> config) : base(config) { }
    }
}
