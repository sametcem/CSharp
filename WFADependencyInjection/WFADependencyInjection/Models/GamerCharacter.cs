using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFADependencyInjection.Models.Characters;

namespace WFADependencyInjection.Models
{
    public class GamerCharacter
    {
        ICharacter _character;

        public GamerCharacter(ICharacter _char )
        {
            _character = _char;
        }

        public void combo()
        {
            _character.Attack();
            _character.Attack();
            _character.Defence();
            _character.Attack();
            _character.Stop();


        }
    }
}
