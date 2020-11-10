using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HjælpLone
{
    class Wizard : Caster , IWizard
    {
        public override void Die()
        {
            throw new NotImplementedException();
        }

        public void Teleport(int x, int y)
        {
            throw new NotImplementedException();
        }

        public void ThrowFrostNova()
        {
            throw new NotImplementedException();
        }

        public override void ThrowMagicMissile()
        {
            throw new NotImplementedException();
        }

        public Wizard(string name)
        {
            Name = name;
            HP = 100;
        }
    }
}
