using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HjælpLone
{
    class Barbarian : Character, IBarbarian, IFighter
    {
        public void Bash()
        {
            throw new NotImplementedException();
        }

        public void Cleave()
        {
            throw new NotImplementedException();
        }

        public override void Die()
        {
            throw new NotImplementedException();
        }

        public void Fight()
        {
            throw new NotImplementedException();
        }

        public Barbarian(string name)
        {
            Name = name;
            HP = 150;
        }
    }
}
