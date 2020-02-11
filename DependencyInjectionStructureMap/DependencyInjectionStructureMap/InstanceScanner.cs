using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionStructureMap
{
    public class InstanceScanner : Registry
    {
        public InstanceScanner()
        {
            Scan(_ =>
            {
                _.TheCallingAssembly();
                _.WithDefaultConventions(); // I for Interface
            });

            For<WriterX>().Use<Writer>();
        }
    }
}
