using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamRPG
{
    internal class Enemy
    {
        public string Name { get;}
        public int Atk { get; }
        public int Hp { get; set; }

        public Enemy(string name, int atk, int hp)
        {
            Name = name;
            Atk = atk;
            Hp = hp;
        }
    }
}
