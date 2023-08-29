using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG;

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

        public static int CalculateDamage(int atk) //랜덤데미지 값 반환함수
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
            damage = rand.Next(atk - randDmg, atk + randDmg +1);
            return damage;
        }
    }

    public class Character : CharacterBase
    {
        public string Job { get; }
        
        public int Def { get; set; }
        
        public int Gold { get; set; }

        // ----- 김형수 -----
        public long Exp { get; set; }
        // -----

        // ---------- Song ---------------
        // Mp 구현
        public int Mp { get; set; }
        public int CurrentMp { get; set; }
        // 스킬 목록 구현
        public List <Skill> skills { get; set; }

        public Character(string name, string job, int lv, int atk, int def, int hp, int gold, string isDead, int mp) : base(name, atk, lv, hp, isDead)
        {
            Job = job;
            Def = def;
            CurrentHp = hp;
            Gold = gold;
            CurrentMp = mp;
            Mp = mp;
            skills = new List<Skill> { };
        }
        public void AddSkill(Skill skill)
        {
            skills.Add(skill);
        }
        // ---------- Song ---------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="amount">획득한 경험치 양</param>
        /// 
        // ----- 김형수 -----

        public void LvUp()
        {
            Lv++;
            Atk += 1;
            Def += 1;
            Hp += 10;
        }

        public void GetExp(long amount)
        {
            Exp += amount;

            // 필요 경험치: 레벨 * 1000 
            long needExp = Lv * 1000;

            while(Exp >= needExp)
            {
                LvUp();

                Exp -= 1000;
            }
        }

        // -----
        
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
