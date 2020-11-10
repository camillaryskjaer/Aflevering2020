using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HjælpLone
{
    class Witch : Character, IWitch, ICaster
    {
        public override void Die()
        {
            throw new NotImplementedException();
        }

        public void Heal()
        {
            throw new NotImplementedException();
        }

        public void ThrowMagicMissile()
        {
            throw new NotImplementedException();
        }

        public Witch(string name)
        {
            Name = name;
            HP = 90;
        }
    }
}
