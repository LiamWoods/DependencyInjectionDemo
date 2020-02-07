using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleInjectorDemo
{
    public class ConcreteRepository
    {
        public ConcreteRepository()
        {

        }

        public bool GetABool()
        {
            // Do something databasey
            return false;
        }

    }
}
