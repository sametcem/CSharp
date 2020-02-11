using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFADependencyInjection.Models.Characters
{
    public interface ICharacter
    {
         void Attack();
         void Defence();
         void Run();
         void Walk();
         void Stop();
    }
}
