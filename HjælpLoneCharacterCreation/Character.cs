using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HjælpLone
{
    abstract class Character
    {
        public string Name { get; set; }
        public int HP { get; set; }

        public abstract void Die();
    }
}
