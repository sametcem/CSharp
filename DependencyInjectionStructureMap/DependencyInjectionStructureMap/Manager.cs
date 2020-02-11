using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionStructureMap
{
    public class Manager
    {
        public ILogger _logger;
        public WriterX _writer;

        public Manager(ILogger logger, WriterX writer)
        {
            _logger = logger;
            _writer = writer;
        }

        public void ManagerWriter()
        {
            _logger.WriteHerePlease("Hi, I am a Manager!");
            Console.ReadLine();
        }

        public void WriterX()
        {
            _writer.WriteOnMyWall("Go Away. Come back tomorrow");
            Console.ReadLine();
        }
    }
}
