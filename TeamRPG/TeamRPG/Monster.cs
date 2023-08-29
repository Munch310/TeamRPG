using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TeamRPG;

namespace TeamRPG
{
    public class Monsters
    {
        public static StringBuilder sb = new StringBuilder(); //빠른출력을 위해 사용

        public static List<CharacterBase> monstersList;

        //==================전투===============================
        public Monsters()
        {
            monstersList = new List<CharacterBase>();
        }

        public void AddMonster2List(CharacterBase _Monster)
        {
            monstersList.Add(_Monster);
        }

        public static void FightInfo() //전투메서드
        {
            Console.Clear();
            Console.WriteLine("Battle!");
            Console.WriteLine();

            for (int i = 0; i < monstersList.Count; i++)
            {
                sb.Append($"Lv.{monstersList[i].Lv} ");
                sb.Append($"{monstersList[i].Name} ");
                sb.Append($"HP {monstersList[i].Hp}" + "\n");
            }
            Console.WriteLine(sb);
            sb.Clear();

            Console.WriteLine("[내 정보]");
            sb.Append($"Lv.{MainProgram.player.Lv} ");
            sb.Append($"{MainProgram.player.Name} {MainProgram.player.Job}");
            sb.Append('\n');
            sb.Append($"HP {MainProgram.player.CurrentHp} / {MainProgram.player.Hp}");
            Console.WriteLine(sb);
            sb.Clear();

            Console.WriteLine();
            Console.WriteLine("1. 공격");
            Console.WriteLine();
            Console.WriteLine("0. 메인화면으로");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.WriteLine();

            int input = Utility.CheckValidInput(1, 1);
            if (input == 1)
            {
                Console.WriteLine("전투 창으로 이동합니다.");
                Thread.Sleep(300);
                BattleTime();
            }
            if (input == 0)
            {
                Console.WriteLine();
                Console.WriteLine("메인화면으로 돌아갑니다..");
                Thread.Sleep(300);
                MainProgram.DisplayGameIntro();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("숫자를 다시 입력하세요");
                Console.WriteLine();
                Thread.Sleep(300);
                FightInfo();
            }
        }

        public static void BattleTime()
        {
            Console.Clear();
            Console.WriteLine("Battle!");
            Console.WriteLine();

            for (int i = 0; i < monstersList.Count; i++)
            {
                sb.Append($"{i + 1}. ");
                sb.Append($"Lv.{monstersList[i].Lv} ");
                sb.Append($"{monstersList[i].Name} ");
                sb.Append($"HP {monstersList[i].CurrentHp}" + "\n");
            }
            Console.WriteLine(sb);
            sb.Clear();

            Console.WriteLine("[내 정보]");
            sb.Append($"Lv.{MainProgram.player.Lv} ");
            sb.Append($"{MainProgram.player.Name} {MainProgram.player.Job}");
            sb.Append('\n');
            sb.Append($"HP {MainProgram.player.CurrentHp} / {MainProgram.player.Hp}");
            Console.WriteLine(sb);
            sb.Clear();

            Console.WriteLine();
            Console.WriteLine("0. 도망가기");
            Console.WriteLine();
            Console.WriteLine("대상을 선택해주세요.");
            Console.WriteLine();

            int input = Utility.CheckValidInput(0, monstersList.Count);

            if (input == 0)
            {
                Console.WriteLine("도망치기를 선택했습니다.");
                Console.WriteLine();
                Console.WriteLine("메인화면으로 돌아갑니다.");
                Console.WriteLine();
                Thread.Sleep(300);
                MainProgram.DisplayGameIntro();
            }
            else if (1 <= input && input <= monstersList.Count)
            {
                PlayerPhase(input);
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
            }
        }

        // --------------------------8.29 수정해야함!------------------------------------------------
        public static void PlayerPhase(int selected) //플레이어 공격패턴
        {
            int playerDmg = CharacterBase.CalculateDamage(MainProgram.player.Atk);
            Console.WriteLine();
            Console.WriteLine($"==============================================================");
            Console.WriteLine();

            if (monstersList[selected - 1].Hp > 0)
            {
                Console.WriteLine($"{MainProgram.player.Name} 의 공격!");
                sb.Append($"Lv.{monstersList[selected - 1].Lv} ");
                sb.Append($"{monstersList[selected - 1].Name} 을(를) 맞췄습니다. ");
                sb.Append($"[데미지 : {playerDmg} ]\n\n");
                sb.Append($"Lv.{monstersList[selected - 1].Lv} {monstersList[selected - 1].Name}\n");
                Console.WriteLine(sb);
                sb.Clear();

                if (monstersList[selected - 1].Hp - playerDmg <= 0)
                {
                    Console.WriteLine($"{monstersList[selected - 1].Hp} -> {monstersList[selected - 1].IsDead}");
                }
                else
                {
                    Console.WriteLine($"{monstersList[selected - 1].Hp} -> {monstersList[selected - 1].Hp - playerDmg}");
                }
                Console.WriteLine();
                Console.WriteLine($"==============================================================");
                Console.WriteLine();
                Console.WriteLine("0. 적 차례");
                Console.WriteLine();
                Console.ReadLine();
                int input = Utility.CheckValidInput(0, 1);
                if (input == 0)
                {
                    EnemyPhase();
                }
            }
            else
            {
                Console.WriteLine("이미 죽은 적입니다. 다른 적을 선택하세요");

            }
        }

        public static void EnemyPhase() //적 공격패턴
        {
            
            Console.WriteLine();
            Console.WriteLine($"==============================================================");
            Console.WriteLine();

            if (MainProgram.player.Hp > 0)
            {
                for (int i = 0; i < monstersList.Count; i++)
                {
                    int monsDmg = CharacterBase.CalculateDamage(monstersList[i].Atk);
                    sb.Append($"Lv.{monstersList[i].Lv} ");
                    sb.Append($"{monstersList[i].Name} 의 공격\n");
                    sb.Append($"{MainProgram.player.Name}을 맞췄습니다. [데미지 : {monsDmg}]");
                    sb.Append("\n\n");
                    sb.Append($"Lv.{ MainProgram.player.Lv} {MainProgram.player.Name}\n");
                    sb.Append($"HP {MainProgram.player.CurrentHp} -> {MainProgram.player.CurrentHp -= monsDmg}");
                    Console.WriteLine($"----- {MainProgram.player.CurrentHp}");
                    Console.WriteLine($"----- {MainProgram.player.Hp}");
                    Console.WriteLine(sb);
                    Console.WriteLine();
                    Console.WriteLine($"==============================================================");
                    Console.WriteLine();
                    Console.WriteLine("다음");
                    Console.WriteLine();
                    Console.WriteLine($"==============================================================");
                    Console.WriteLine();
                    Console.ReadKey();
                    sb.Clear();
                }
                Console.WriteLine("0. 플레이어 차례");
                Console.WriteLine();
                Console.ReadLine();
                int input = Utility.CheckValidInput(0, 0);
                if (input == 0)
                {
                    BattleTime();
                }

            }
        }
        //------------------------------------------------------------------------------------------------
    }
    //---------------------------------------------------------
}
