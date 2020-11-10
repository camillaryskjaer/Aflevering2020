using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HjælpLone
{
    class Knight : Fighter, IKnight
    {
        public override void Die()
        {
            throw new NotImplementedException();
        }

        public void RaiseShield()
        {
            throw new NotImplementedException();
        }

        public void ShieldGlare()
        {
            throw new NotImplementedException();
        }

        public void Slash()
        {
            throw new NotImplementedException();
        }

        public override void Fight()
        {
            throw new NotImplementedException();
        }

        public Knight(string name)
        {
            Name = name;
            HP = 200;
        }
    }
}
