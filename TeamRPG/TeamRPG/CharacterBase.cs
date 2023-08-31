using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG;
using System.Text.Json;

namespace TeamRPG
{
    public abstract class CharacterBase
    {
        public static Random rand = new Random();

        public string IsDead { get; set; }
        public string Name { get; set; }
        public int Atk { get; set; }
        public int Lv { get; set; }
        public int Hp { get; set; }
        public int CurrentHp { get; set; }


        public CharacterBase(string name, int atk, int lv, int hp, string isDead)
        {
            Name = name;
            Atk = atk;
            Lv = lv;
            Hp = hp;
            IsDead = isDead;
            CurrentHp = hp;
        }

        public static int CalculateDamage(int atk)
        {
            int damage = 0;
            int randDmg = 0;
            if (atk % 10 != 0)
            {
                randDmg = atk / 10 + 1;
            }
            else
            {
                randDmg = atk / 10;
            }
            damage = rand.Next(atk - randDmg, atk + randDmg + 1);
            return damage;
        }
    }

    public class Character : CharacterBase
    {
        public string Job { get; }
        public int Def { get; set; }
        public int Gold { get; set; }
        public int Exp { get; set; }
        public int needExp { get; set; }
        public int Mp { get; set; }
        public int CurrentMp { get; set; }
        public List<Skill> skills { get; set; }

        public Character(string name, string job, int lv, int atk, int def, int hp, int gold, string isDead, int mp) : base(name, atk, lv, hp, isDead)
        {
            Job = job;
            Def = def;
            CurrentHp = hp;
            Gold = gold;
            CurrentMp = mp;
            Mp = mp;
            needExp = 10;
            skills = new List<Skill> { };
            needExp = 10;
        }

        public void AddSkill(Skill skill)
        {
            skills.Add(skill);
        }

        public void LvUp()
        {
            Exp -= needExp;
            Lv++;
            Atk += 1;
            Def += 1;
            SetNeedExp(Lv);
        }

        public void SetNeedExp(int lv)
        {
            switch (lv)
            {
                case 1:
                    needExp = 10;
                    break;

                case 2:
                    needExp = 35;
                    break;

                case 3:
                    needExp = 65;
                    break;

                case 4:
                    needExp = 100;
                    break;

                default:
                    break;
            }
        }

        public void GetExp(int amount)
        {
            Exp += amount;

            if (Exp >= needExp)
            {
                LvUp();
            }
        }
    }

    class Minion : CharacterBase
    {
        public Minion(string name, int atk, int hp, int lv, string isDead) : base(name, atk, lv, hp, isDead)
        {
            CurrentHp = hp;
        }
    }

    class CanonMinion : CharacterBase
    {
        public CanonMinion(string name, int atk, int hp, int lv, string isDead) : base(name, atk, lv, hp, isDead)
        {
            CurrentHp = hp;
        }
    }

    class VoidMinion : CharacterBase
    {
        public VoidMinion(string name, int atk, int hp, int lv, string isDead) : base(name, atk, lv, hp, isDead)
        {
            CurrentHp = hp;
        }
    }
}