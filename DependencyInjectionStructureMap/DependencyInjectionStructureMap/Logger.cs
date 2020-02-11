using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionStructureMap
{
    public interface ILogger
    {
        void WriteHerePlease(string text);
    }

    public class Logger : ILogger
    {
        public void WriteHerePlease(string text)
        {
            Console.WriteLine(text);
            Console.WriteLine("Good bye Manager!");
        }
    }
}
