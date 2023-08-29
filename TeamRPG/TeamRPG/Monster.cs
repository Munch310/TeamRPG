using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TeamRPG;
using static System.Net.Mime.MediaTypeNames;

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
            // ---------- Song Mp 추가 ---------------
            sb.Append('\n');
            sb.Append($"MP {MainProgram.player.CurrentMp} / {MainProgram.player.Mp}");
            // ---------- Song ---------------
            Console.WriteLine(sb);
            sb.Clear();

            Console.WriteLine();
            Console.WriteLine("1. 공격");
            Console.WriteLine();
            // ---------- Song 스킬추가 ---------------
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
            // ---------- Song 스킬 창 추가---------------
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

        public static void BattleTime() // 스킬을 사용하지 않은 기본 공격
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
            sb.Append('\n');
            sb.Append($"MP {MainProgram.player.CurrentMp} / {MainProgram.player.Mp}");
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
                PlayerAttack(input, CharacterBase.CalculateDamage(MainProgram.player.Atk));
                PlayerPhase();
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
            }
        }

        // --------------------------------------------------------------------------
        public static void PlayerPhase() //플레이어 기본공격패턴
        {
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

        public static void PlayerAttack(int selected, int damage)
        {
            // 치명타 기능
            Random rand = new Random();
            int criticalEvasionCheck = rand.Next(20);
            if (criticalEvasionCheck <= 3)
            {
                damage *= 2;
                Console.WriteLine("치명타가 터졌습니다!");
            }

            // 회피할 경우 공격 스킵
            if (criticalEvasionCheck > 17)
            {
                Console.WriteLine("적이 공격을 회피했습니다!");
            }

            else
            {
                if (monstersList[selected - 1].CurrentHp > 0)
                {
                    Console.WriteLine($"{MainProgram.player.Name} 의 공격!\n");
                    sb.Append($"Lv.{monstersList[selected - 1].Lv} ");
                    sb.Append($"{monstersList[selected - 1].Name} 을(를) 맞췄습니다. ");
                    sb.Append($"[데미지 : {damage} ]\n\n");
                    sb.Append($"Lv.{monstersList[selected - 1].Lv} {monstersList[selected - 1].Name}\n");
                    Console.Write(sb);
                    sb.Clear();
                    // -------- 송명근 전투부분 수정 -------
                    if (monstersList[selected - 1].CurrentHp - damage <= 0)
                    {

                        Console.WriteLine($"{monstersList[selected - 1].CurrentHp} -> {monstersList[selected - 1].IsDead}");
                        monstersList[selected - 1].CurrentHp = 0;
                    }
                    else
                    {
                        Console.WriteLine($"{monstersList[selected - 1].CurrentHp} -> {monstersList[selected - 1].CurrentHp -= damage}");
                    }
                }
                else
                {
                    Console.WriteLine("이미 죽은 적입니다. 다른 적을 선택하세요");
                    Console.WriteLine();
                    Console.WriteLine($"==============================================================");
                    Console.WriteLine();
                    SelectMonster(damage);
                }
            }
        }

        // --- Song 스킬을 이용한 전투 추가 ---
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
            sb.Append('\n');
            sb.Append($"MP {MainProgram.player.CurrentMp} / {MainProgram.player.Mp}");
            // ---------- Song ---------------
            Console.WriteLine(sb);
            sb.Clear();

            Console.WriteLine();
            for (int i = 0; i < MainProgram.player.skills.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {MainProgram.player.skills[i].Name} - MP {MainProgram.player.skills[i].MpConsume}");
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
                PlayerSkill(input);
                PlayerPhase();
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
            }
        }

        public static void PlayerSkill(int selected)
        {
            if (MainProgram.player.CurrentMp < MainProgram.player.skills[selected - 1].MpConsume)
            {
                Console.WriteLine("마나가 부족합니다.");
                Console.WriteLine("아무 키나 눌러 돌아가기");
                Console.ReadLine();
                FightInfo();

            }
            else if (MainProgram.player.skills[selected-1].Name == "알파 스트라이크")
            {
                Console.WriteLine("알파 스트라이크를 시전할 대상을 선택해주세요");
                SelectMonster(MainProgram.player.Atk * 2);
                // 마나 소모
                MainProgram.player.CurrentMp -= MainProgram.player.skills[selected - 1].MpConsume;
            }
            else if (MainProgram.player.skills[selected - 1].Name == "더블 스트라이크")
            {
                Console.WriteLine("더블 스트라이크 시전!");
                List<int> temp = new List<int>();
                for (int i = 0; i < monstersList.Count; i++)
                {
                    if (monstersList[i].CurrentHp != 0)
                    {
                        temp.Add(i);
                    }
                }
                if (temp.Count == 1)
                {
                    PlayerAttack(temp[0]+1, MainProgram.player.Atk);
                }
                else if (temp.Count == 2)
                {
                    PlayerAttack(temp[0]+1, MainProgram.player.Atk);
                    PlayerAttack(temp[1]+1, MainProgram.player.Atk);
                }
                else if (temp.Count > 2)
                {
                    Random rand = new Random();
                    int firstTarget = rand.Next(1, temp.Count);
                    int secondTarget = rand.Next(1, temp.Count - 1);
                    if (firstTarget <= secondTarget) // 중복 제거
                    {
                        secondTarget += 1;
                    }
                    PlayerAttack(temp[firstTarget-1]+1, MainProgram.player.Atk);
                    PlayerAttack(temp[secondTarget-1]+1, MainProgram.player.Atk);
                }
                // 마나 소모
                MainProgram.player.CurrentMp -= MainProgram.player.skills[selected - 1].MpConsume;
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
                    FightInfo();
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
                    return false;
                }
            }
            return true;
        }

        public static void SelectMonster(int damage)
        {
            int input = Utility.CheckValidInput(0, monstersList.Count);
            if (1 <= input && input <= monstersList.Count)
            {
                PlayerAttack(input, damage);
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
    //-----------------------------------------------------
}
