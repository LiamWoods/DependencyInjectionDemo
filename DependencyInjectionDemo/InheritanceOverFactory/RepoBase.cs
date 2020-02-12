using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionDemo.InheritanceOverFactory
{
    public class RepoBase<TConfig> : IRepo<TConfig> where TConfig : RepoConfig, new()
    {
        private TConfig _config;

        // Accepts IOptions so is fully usable as base class
        public RepoBase(IOptions<TConfig> config)
        {
            _config = config.Value;
        }

        public virtual string GetSomething()
        {
            return this.ToString();
        }

        public override string ToString()
        {
            return $"{nameof(_config.Name)}: {_config.Name} {nameof(_config.Address)}: {_config.Address}";
        }
    }
}
