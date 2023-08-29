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

        public static List<CharacterBase> GetMonstersList() //다른클래스에서 몬스터클래스를 사용하기위한 반환값
        {
            return monstersList;
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
                sb.Append($"HP {monstersList[i].CurrentHp}" + "\n");
            }
            Console.WriteLine(sb);
            sb.Clear();

            Console.WriteLine("[내 정보]");
            sb.Append($"Lv.{MainProgram.player.Lv} ");
            sb.Append($"{MainProgram.player.Name} {MainProgram.player.Job}");
            sb.Append('\n');
            sb.Append($"HP {MainProgram.player.CurrentHp} / {MainProgram.player.Hp}");
            // ---------- Song ---------------
            sb.Append($"MP {MainProgram.player.CurrentMp} / {MainProgram.player.Mp}");
            // ---------- Song ---------------
            Console.WriteLine(sb);
            sb.Clear();

            Console.WriteLine();
            Console.WriteLine("1. 공격");
            Console.WriteLine();
            // ---------- Song ---------------
            Console.WriteLine("2. 스킬");
            // ---------- Song ---------------
            Console.WriteLine();
            Console.WriteLine("0. 메인화면으로");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.WriteLine();

            int input = Utility.CheckValidInput(1, 1);
            if (input == 1)
            {
                Console.WriteLine("공격 창으로 이동합니다.");
                Thread.Sleep(300);
                BattleTime();
            }
            // ---------- Song ---------------
            else if (input == 2)
            {
                Console.WriteLine("스킬 창으로 이동합니다.");
                Thread.Sleep(300);
                BattleSkill();
            }
            // ---------- Song ---------------
            else if (input == 0)
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
        public static void BattleSkill()
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
            // ---------- Song ---------------
            sb.Append($"MP {MainProgram.player.CurrentMp} / {MainProgram.player.Mp}");
            // ---------- Song ---------------
            Console.WriteLine(sb);
            sb.Clear();

            Console.WriteLine();
            for (int i = 0; i < MainProgram.player.skills.Count;i++)
            {
                Console.WriteLine($"{i+1}. {MainProgram.player.skills[i].Name} - MP{MainProgram.player.skills[i].MpConsume}");
                Console.WriteLine($"{MainProgram.player.skills[i].Description}");
            }
            Console.WriteLine("0. 취소");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요");


            int input = Utility.CheckValidInput(0, monstersList.Count);

            if (input == 0)
            {
                FightInfo();
            }
            else if (1 <= input && input <= MainProgram.player.skills.Count)
            {
                // 스킬 사용 후
                Console.WriteLine(" 스킬 사용 !");
                FightInfo();
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
            }
        }

        public static void BattleTime()
        {
            Console.Clear();
            Console.WriteLine("Battle!");
            Console.WriteLine();

            for (int i = 0; i < monstersList.Count; i++)
            {
                if (monstersList[i].CurrentHp > 0)
                {
                    sb.Append($"{i + 1}. ");
                    sb.Append($"Lv.{monstersList[i].Lv} ");
                    sb.Append($"{monstersList[i].Name} ");
                    sb.Append($"HP {monstersList[i].CurrentHp}" + "\n");
                    Console.WriteLine(sb);
                    sb.Clear();
                }
                else if(monstersList[i].CurrentHp <= 0)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write($"{i + 1}. ");
                    Console.Write($"Lv.{monstersList[i].Lv} ");
                    Console.Write($"{monstersList[i].Name} ");
                    Console.WriteLine($"{monstersList[i].IsDead} \n");
                    Console.ResetColor();
                }
            }
            

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

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("[ 플레이어 턴 ]");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();



            if (monstersList[selected - 1].CurrentHp > 0)
            {
                Console.WriteLine($"{MainProgram.player.Name} 의 공격!\n\n");
                sb.Append($"Lv.{monstersList[selected - 1].Lv} ");
                sb.Append($"{monstersList[selected - 1].Name} 을(를) 맞췄습니다. ");
                sb.Append($"[데미지 : {playerDmg} ]\n\n");
                sb.Append($"Lv.{monstersList[selected - 1].Lv} {monstersList[selected - 1].Name}\n");
                Console.WriteLine(sb);
                sb.Clear();

                if (monstersList[selected - 1].CurrentHp - playerDmg <= 0)
                {
                    
                    Console.WriteLine($"{monstersList[selected - 1].CurrentHp} -> {monstersList[selected - 1].IsDead}");
                    monstersList[selected - 1].CurrentHp -= playerDmg;
                }
                else
                {
                    Console.WriteLine($"{monstersList[selected - 1].CurrentHp} -> {monstersList[selected - 1].CurrentHp -= playerDmg}");
                }
                Console.WriteLine();
                Console.WriteLine($"==============================================================");
                Console.WriteLine();
                if (CheckAllMonstersDefeated())
                {
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine($"==============================================================");
                    Console.WriteLine();
                    Console.WriteLine("Battle!! - Result");
                    Console.WriteLine();
                    Console.WriteLine("Victory!");
                    Console.WriteLine();
                    Console.WriteLine("아무키를 눌러 메인화면으로 되돌아 가십시오");
                    Console.WriteLine();
                    Console.WriteLine($"==============================================================");
                    Console.WriteLine();
                    Console.ReadLine();
                    MainProgram.DisplayGameIntro();
                }
                else
                {
                    Console.WriteLine("0. 적 차례");
                    Console.WriteLine();
                    int input = Utility.CheckValidInput(0, 1);
                    if (input == 0)
                    {
                        EnemyPhase();
                    }
                }
            }
            else
            {
                Console.WriteLine("이미 죽은 적입니다. 다른 적을 선택하세요");
                Console.WriteLine();
                Console.WriteLine($"==============================================================");
                Console.WriteLine();
                int input = Utility.CheckValidInput(0, monstersList.Count);
                if (1 <= input && input <= monstersList.Count)
                {
                    PlayerPhase(input);
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.WriteLine();
                    Console.WriteLine($"==============================================================");
                    Console.WriteLine();
                    Thread.Sleep(500);
                    BattleTime();
                }
            }
            
        }

        public static void EnemyPhase() //적 공격패턴
        {
            
            Console.WriteLine();
            Console.WriteLine($"==============================================================");
            Console.WriteLine();

            

            if (MainProgram.player.CurrentHp > 0)
            {
                for (int i = 0; i < monstersList.Count; i++)
                {
                    int saveCurrentHp = 0; // 플레이어 currentHp를 저장하기 위한 변수
                    if (monstersList[i].CurrentHp <= 0)
                    {
                        continue;
                    }

                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("[ 몬스터 턴 ]");
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.WriteLine();

                    int monsDmg = CharacterBase.CalculateDamage(monstersList[i].Atk);
                    sb.Append($"Lv.{monstersList[i].Lv} ");
                    sb.Append($"{monstersList[i].Name} 의 공격\n\n");
                    sb.Append($"{MainProgram.player.Name}을 맞췄습니다. [데미지 : {monsDmg}]");
                    sb.Append("\n\n");
                    sb.Append($"Lv.{ MainProgram.player.Lv} {MainProgram.player.Name}\n");

                    saveCurrentHp = MainProgram.player.CurrentHp;
                    MainProgram.player.CurrentHp -= monsDmg;
                    if (MainProgram.player.CurrentHp <= 0)
                    {
                        //sb.Append($"HP {MainProgram.player.CurrentHp} -> 0");
                        sb.Append($"HP {saveCurrentHp} -> 0");
                        Console.WriteLine(sb);
                        Console.WriteLine();
                        Console.Clear();
                        Console.WriteLine($"==============================================================");
                        Console.WriteLine();
                        Console.WriteLine("Battle!! - Result");
                        Console.WriteLine();
                        Console.WriteLine("Game Over...");
                        Console.WriteLine();
                        Console.WriteLine("아무키를 눌러 메인화면으로 되돌아 가십시오");
                        Console.WriteLine();
                        Console.WriteLine($"==============================================================");
                        Console.WriteLine();
                        sb.Clear();
                        Console.ReadLine();
                        Environment.Exit(0);
                        //캐릭터생성부로 돌아가는 함수();
                    }
                    else
                    {
                        //sb.Append($"HP {MainProgram.player.CurrentHp} -> {MainProgram.player.CurrentHp - monsDmg}");
                        sb.Append($"HP {saveCurrentHp} -> {MainProgram.player.CurrentHp}");
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
                    
                    
                }
                Console.WriteLine("0. 플레이어 차례");
                Console.WriteLine();
                int input = Utility.CheckValidInput(0, 0);
                if (input == 0)
                {
                    BattleTime();
                }
            }
            else
            {
                Console.WriteLine("Game Over...");
                Console.WriteLine();
                Console.WriteLine("아무키를 눌러 메인화면으로 되돌아 가십시오");
                Console.WriteLine();
                Console.WriteLine($"==============================================================");
                Console.WriteLine();
                Console.ReadLine();
                MainProgram.DisplayGameIntro();
            }
        }

        public static bool CheckAllMonstersDefeated() //몬스터가 모두 죽었는지 판별하는 함수
        {
            foreach (CharacterBase monster in monstersList)
            {
                if (monster.CurrentHp > 0)
                {
                    return false; // 아직 살아있는 몬스터가 있다면 전투는 아직 승리하지 않은 상태
                }
            }
            return true; // 모든 몬스터의 CurrentHp가 0 이하인 경우, 전투에서 승리한 상태
        }
        //------------------------------------------------------------------------------------------------
    }
    //-----------------------------------------------------
}
