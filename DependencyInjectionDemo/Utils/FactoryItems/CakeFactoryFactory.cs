using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionDemo.Utils.FactoryItems
{
    public class CakeFactoryFactory
    {
        public ICakeFactory GetFactory(string factoryType)
        {
            // Facilitates more logic around which implementation you require
            switch (factoryType)
            {
                case "fresh":
                    return new FreshCakeFactory();
                case "stale":
                    return new WarehouseCakeFactory();
                default:
                    throw new ArgumentException("No matching cake factory");
            }
        }
    }
}
