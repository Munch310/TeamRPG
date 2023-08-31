using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
        public static StringBuilder sb = new StringBuilder();

        public static List<CharacterBase> monstersList;

        public Monsters()
        {
            monstersList = new List<CharacterBase>();
        }

        public static List<CharacterBase> GetMonstersList()
        {
            return monstersList;
        }

        public static void sbClear()
        {
            Console.WriteLine(sb);
            sb.Clear();
        }

        public void AddMonster2List(CharacterBase _Monster)
        {
            monstersList.Add(_Monster);
        }

        public static void FightInfo()
        {
            Console.Clear();

            UI.DisplayGameUI();
            Console.SetCursorPosition(35, 2);
            Console.WriteLine("[전투]");

            for (int i = 0; i < monstersList.Count; i++)
            {
                if (monstersList[i].CurrentHp > 0)
                {
                    Console.SetCursorPosition(2 + (i * 26), 7);
                    Console.Write($"Lv.{monstersList[i].Lv} ");
                    Console.Write($"{monstersList[i].Name} ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"HP {monstersList[i].CurrentHp}" + "\n");
                    Console.ResetColor();
                }
                else if (monstersList[i].CurrentHp <= 0)
                {
                    Console.SetCursorPosition(2 + (i * 26), 7);
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write($"Lv.{monstersList[i].Lv} ");
                    Console.Write($"{monstersList[i].Name} ");
                    Console.WriteLine($"{monstersList[i].IsDead} \n");
                    Console.ResetColor();
                }
            }

            Console.SetCursorPosition(3, 10);
            Console.WriteLine("[내 정보]");

            Console.SetCursorPosition(3, 12);
            sb.Append($"Lv.{MainProgram.player.Lv} ");
            sbClear();
            Console.SetCursorPosition(3, 14);
            sb.Append($"{MainProgram.player.Name} {MainProgram.player.Job}");
            sbClear();
            Console.SetCursorPosition(3, 16);
            sb.Append($"HP {MainProgram.player.CurrentHp} / {MainProgram.player.Hp}");
            sbClear();
            Console.SetCursorPosition(3, 18);
            sb.Append($"MP {MainProgram.player.CurrentMp} / {MainProgram.player.Mp}");
            sbClear();

            Console.SetCursorPosition(2, 23);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" [1] ");
            Console.ResetColor();
            Console.WriteLine("공격 ");
            Console.SetCursorPosition(24, 23);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" [2] ");
            Console.ResetColor();
            Console.WriteLine("스킬 ");
            Console.SetCursorPosition(48, 23);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" [0] ");
            Console.ResetColor();
            Console.WriteLine("도망가기 ");
            Console.SetCursorPosition(3, 27);
            Console.Write("숫자를 입력해주세요: ");

            int input = Utility.CheckValidInput(0, 2);
            if (input == 1)
            {
                Console.SetCursorPosition(3, 27);
                Console.WriteLine("공격 창으로 이동합니다.");
                Thread.Sleep(300);
                BattleNormal();
            }
            else if (input == 2)
            {
                Console.SetCursorPosition(3, 27);
                Console.WriteLine("스킬 창으로 이동합니다.");
                Thread.Sleep(300);
                BattleSkill();
            }
            else if (input == 0)
            {
                Console.SetCursorPosition(3, 27);
                Console.WriteLine("메인화면으로 돌아갑니다..");
                Thread.Sleep(300);
                MainProgram.DisplayGameIntro();
            }
            else
            {
                Console.SetCursorPosition(3, 27);
                Console.WriteLine("숫자를 다시 입력하세요");
                Console.WriteLine();
                Thread.Sleep(300);
                FightInfo();
            }
        }

        public static void BattleNormal()
        {
            Console.Clear();
            UI.DisplayGameUI();
            Console.SetCursorPosition(32, 2);
            Console.WriteLine("[기본 공격]");

            for (int i = 0; i < monstersList.Count; i++)
            {
                if (monstersList[i].CurrentHp > 0)
                {
                    Console.SetCursorPosition(2 + (i * 26), 7);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"[{i + 1}] ");
                    Console.ResetColor();
                    Console.Write($"Lv.{monstersList[i].Lv} ");
                    Console.Write($"{monstersList[i].Name} ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"HP {monstersList[i].CurrentHp}" + "\n");
                    Console.ResetColor();
                }
                else if (monstersList[i].CurrentHp <= 0)
                {
                    Console.SetCursorPosition(2 + (i * 26), 7);
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write($"[{i + 1}] ");
                    Console.Write($"Lv.{monstersList[i].Lv} ");
                    Console.Write($"{monstersList[i].Name} ");
                    Console.WriteLine($"{monstersList[i].IsDead} \n");
                    Console.ResetColor();
                }
            }

            Console.SetCursorPosition(3, 10);
            Console.WriteLine("[내 정보]");

            Console.SetCursorPosition(3, 12);
            sb.Append($"Lv.{MainProgram.player.Lv} ");
            sbClear();
            Console.SetCursorPosition(3, 14);
            sb.Append($"{MainProgram.player.Name} {MainProgram.player.Job}");
            sbClear();
            Console.SetCursorPosition(3, 16);
            sb.Append($"HP {MainProgram.player.CurrentHp} / {MainProgram.player.Hp}");
            sbClear();
            Console.SetCursorPosition(3, 18);
            sb.Append($"MP {MainProgram.player.CurrentMp} / {MainProgram.player.Mp}");
            sbClear();

            Console.SetCursorPosition(2, 23);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" [0] ");
            Console.ResetColor();
            Console.WriteLine("돌아가기");
            Console.SetCursorPosition(3, 27);
            Console.Write("대상을 입력해주세요: ");

            int input = Utility.CheckValidInput(0, monstersList.Count);

            if (input == 0)
            {
                Console.SetCursorPosition(3, 27);
                Console.WriteLine("선택화면으로 돌아갑니다.");
                Thread.Sleep(500);
                FightInfo();
            }
            else if (1 <= input && input <= monstersList.Count)
            {
                PlayerAttack(input, CharacterBase.CalculateDamage(MainProgram.player.Atk));
                PlayerPhase();
            }
            else
            {
                Console.SetCursorPosition(3, 27);
                Console.WriteLine("잘못된 입력입니다.");
            }
        }

        public static void PlayerPhase()
        {
            if (CheckAllMonstersDefeated())
            {
                Console.Clear();
                UI.DisplayGameUI();
                Console.SetCursorPosition(35, 2);
                Console.WriteLine("[결과]");
                Console.SetCursorPosition(35, 6);
                Console.WriteLine("Victory!");

                int previousLv = MainProgram.player.Lv;
                int previousHp = MainProgram.player.Hp;
                int previousExp = MainProgram.player.Exp;
                int previousGold = MainProgram.player.Gold;

                int totalMonstersExp = 0;
                int totalMonstersGold = monstersList.Count * 100;

                for (int i = 0; i < monstersList.Count; i++)
                {
                    totalMonstersExp += monstersList[i].Lv;
                }
                
                MainProgram.player.GetExp(totalMonstersExp);
                MainProgram.player.Gold = MainProgram.player.Gold + totalMonstersGold;

                int cursorPositionX = 6;
                int cursorPositionY = 7;

                Console.SetCursorPosition(cursorPositionX, cursorPositionY += 2);
                Console.WriteLine($"던전에서 몬스터 {monstersList.Count}마리를 잡았습니다.");
                Console.SetCursorPosition(cursorPositionX, cursorPositionY += 2);
                Console.WriteLine("[캐릭터 정보]");
                Console.SetCursorPosition(cursorPositionX, cursorPositionY += 1);
                Console.WriteLine($"{MainProgram.player.Name}");
                Console.SetCursorPosition(cursorPositionX, cursorPositionY += 1);
                Console.WriteLine($"Lv.{previousLv} -> Lv.{MainProgram.player.Lv}");
                Console.SetCursorPosition(cursorPositionX, cursorPositionY += 1);
                Console.WriteLine($"HP {previousHp} -> {MainProgram.player.CurrentHp} ");
                Console.SetCursorPosition(cursorPositionX, cursorPositionY += 1);
                Console.WriteLine($"exp {previousExp} -> {MainProgram.player.Exp} ");
                Console.SetCursorPosition(cursorPositionX, cursorPositionY += 2); ;
                Console.WriteLine("[획득 아이템]");
                Console.SetCursorPosition(cursorPositionX, cursorPositionY += 1);
                Console.WriteLine($"{previousGold} -> {MainProgram.player.Gold} Gold");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();

                Console.SetCursorPosition(3, 27);
                Console.WriteLine("아무키를 눌러 메인화면으로 되돌아 가십시오");
                Console.ReadLine();
                MainProgram.DisplayGameIntro();
            }
            else
            {
                Console.Clear();
                UI.DisplayGameUI();
                Console.SetCursorPosition(2, 23);
                Console.WriteLine(" 적 차례");
                Console.SetCursorPosition(3, 27);
                Console.Write("아무키를 눌러 적 차례로 진입하십시오");
                Console.ReadKey();
                EnemyPhase();
            }
        }

        public static void PlayerAttack(int selected, int damage)
        {
            Console.Clear();
            UI.DisplayGameUI();

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(32, 2);
            Console.Write("[ 플레이어 턴 ]");
            Console.ResetColor();

            if (monstersList[selected - 1].CurrentHp > 0)
            {
                bool isCrit = false;
                int space = 0;
                Random rand = new Random();
                int criticalEvasionCheck = rand.Next(20);
                if (criticalEvasionCheck <= 3)
                {
                    damage *= 2;
                    isCrit = true;
                    space = 2;
                }

                if (criticalEvasionCheck > 17)
                {
                    Console.SetCursorPosition(3, 10);
                    Console.WriteLine($"{monstersList[selected - 1].Name}이 공격을 회피했습니다!");
                    Console.SetCursorPosition(3, 12);
                    Console.WriteLine($"Hp {monstersList[selected - 1].CurrentHp} -> {monstersList[selected - 1].CurrentHp}");
                }
                else
                {
                    if (isCrit == true)
                    {
                        Console.SetCursorPosition(3, 7);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("치명타가 터졌습니다!");
                        Console.ResetColor();
                    }
                    Console.SetCursorPosition(3, 7 + space);

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine($" {MainProgram.player.Name} ");
                    Console.ResetColor();
                    Console.SetCursorPosition(12, 7 + space);
                    Console.Write($"의 공격!\n");

                    Console.SetCursorPosition(3, 9 + space);
                    Console.WriteLine($"Lv.{monstersList[selected - 1].Lv} ");
                    Console.SetCursorPosition(3, 11 + space);
                    Console.Write($"{monstersList[selected - 1].Name} 을(를) 맞췄습니다. ");
                    Console.WriteLine($"[데미지 : {damage} ]");
                    Console.SetCursorPosition(3, 13 + space);
                    Console.WriteLine($"Lv.{monstersList[selected - 1].Lv} {monstersList[selected - 1].Name}\n");

                    if (monstersList[selected - 1].CurrentHp - damage <= 0)
                    {
                        Console.SetCursorPosition(3, 15 + space);
                        Console.WriteLine($"{monstersList[selected - 1].CurrentHp} -> {monstersList[selected - 1].IsDead}");
                        monstersList[selected - 1].CurrentHp = 0;
                    }
                    else
                    {
                        Console.SetCursorPosition(3, 15 + space);
                        Console.WriteLine($"{monstersList[selected - 1].CurrentHp} -> {monstersList[selected - 1].CurrentHp -= damage}");
                    }
                }
                Console.SetCursorPosition(3, 27);
                Console.WriteLine("아무키를 눌러 다음화면으로 가십시오.");
                Console.ReadLine();
            }
            else
            {
                Console.SetCursorPosition(3, 27);
                Console.WriteLine("이미 죽은 적입니다. 다른 적을 선택하세요.");
                Thread.Sleep(500);
                FightInfo();
            }
        }

        public static void BattleSkill()
        {
            Console.Clear();
            UI.DisplayGameUI();

            Console.SetCursorPosition(35, 2);
            Console.Write("[ 스킬 ]");
            Console.ResetColor();

            for (int i = 0; i < monstersList.Count; i++)
            {
                if (monstersList[i].CurrentHp > 0)
                {
                    Console.SetCursorPosition(2 + (i * 26), 7);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"[{i + 1}] ");
                    Console.ResetColor();
                    Console.Write($"Lv.{monstersList[i].Lv} ");
                    Console.Write($"{monstersList[i].Name} ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"HP {monstersList[i].CurrentHp}" + "\n");
                    Console.ResetColor();
                }
                else if (monstersList[i].CurrentHp <= 0)
                {
                    Console.SetCursorPosition(2 + (i * 26), 7);
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write($"Lv.{monstersList[i].Lv} ");
                    Console.Write($"{monstersList[i].Name} ");
                    Console.WriteLine($"{monstersList[i].IsDead} \n");
                    Console.ResetColor();
                }
            }

            Console.SetCursorPosition(3, 10);
            Console.WriteLine("[내 정보]");

            Console.SetCursorPosition(3, 12);
            sb.Append($"Lv.{MainProgram.player.Lv} ");
            sbClear();
            Console.SetCursorPosition(3, 14);
            sb.Append($"{MainProgram.player.Name} {MainProgram.player.Job}");
            sbClear();
            Console.SetCursorPosition(3, 16);
            sb.Append($"HP {MainProgram.player.CurrentHp} / {MainProgram.player.Hp}");
            sbClear();
            Console.SetCursorPosition(3, 18);
            sb.Append($"MP {MainProgram.player.CurrentMp} / {MainProgram.player.Mp}");
            sbClear();

            Console.SetCursorPosition(1, 22);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" [0] ");
            Console.ResetColor();
            Console.WriteLine("돌아가기 ");

            for (int i = 0; i < MainProgram.player.skills.Count; i++)
            {
                Console.SetCursorPosition(2, 23 + i);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"[{i + 1}] ");
                Console.ResetColor();
                Console.Write($"{MainProgram.player.skills[i].Name} | MP {MainProgram.player.skills[i].MpConsume} ");
                Console.WriteLine($"| {MainProgram.player.skills[i].Description}");
            }

            Console.SetCursorPosition(3, 27);
            Console.Write("스킬을 입력해주세요: ");
            int input = Utility.CheckValidInput(0, MainProgram.player.skills.Count);

            if (input == 0)
            {
                Console.SetCursorPosition(3, 27);
                Console.WriteLine("선택화면으로 돌아갑니다.");
                Thread.Sleep(500);
                FightInfo();
            }
            else if (1 <= input && input <= MainProgram.player.skills.Count)
            {
                PlayerSkill(input);
                PlayerPhase();
            }
            else
            {
                Console.SetCursorPosition(3, 27);
                Console.Write("올바른 스킬을 입력해주세요: ");
                Thread.Sleep(500);
                BattleSkill();
            }
        }

        public static void PlayerSkill(int selected)
        {
            if (MainProgram.player.CurrentMp < MainProgram.player.skills[selected - 1].MpConsume)
            {
                Console.SetCursorPosition(3, 27);
                Console.WriteLine("마나가 부족합니다.    ");
                Console.SetCursorPosition(3, 28);
                Console.WriteLine("아무 키나 눌러 돌아가기");
                Console.ReadLine();
                FightInfo();
            }
            else if (MainProgram.player.skills[selected - 1].Name == "알파 스트라이크")
            {
                Console.SetCursorPosition(3, 27);
                Console.WriteLine("알파 스트라이크를 시전할 대상을 선택해주세요");
                SelectMonster(MainProgram.player.Atk * 2);

                MainProgram.player.CurrentMp -= MainProgram.player.skills[selected - 1].MpConsume;
            }
            else if (MainProgram.player.skills[selected - 1].Name == "더블 스트라이크")
            {
                Console.SetCursorPosition(3, 27);
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
                    PlayerAttack(temp[0] + 1, MainProgram.player.Atk);
                }
                else if (temp.Count == 2)
                {
                    PlayerAttack(temp[0] + 1, MainProgram.player.Atk);
                    PlayerAttack(temp[1] + 1, MainProgram.player.Atk);
                }
                else if (temp.Count > 2)
                {
                    Random rand = new Random();
                    int firstTarget = rand.Next(1, temp.Count);
                    int secondTarget = rand.Next(1, temp.Count - 1);
                    if (firstTarget <= secondTarget)
                    {
                        secondTarget += 1;
                    }
                    PlayerAttack(temp[firstTarget - 1] + 1, MainProgram.player.Atk);
                    PlayerAttack(temp[secondTarget - 1] + 1, MainProgram.player.Atk);
                }

                MainProgram.player.CurrentMp -= MainProgram.player.skills[selected - 1].MpConsume;
            }
            else if (MainProgram.player.skills[selected - 1].Name == "썬더 볼트")
            {
                Console.SetCursorPosition(3, 27);
                Console.WriteLine("썬더 볼트 시전!");
                for (int i = 0; i < monstersList.Count; i++)
                {
                    if (monstersList[i].CurrentHp != 0)
                    {
                        PlayerAttack(i + 1, MainProgram.player.Atk);
                    }
                }

                MainProgram.player.CurrentMp -= MainProgram.player.skills[selected - 1].MpConsume;
            }
            else if (MainProgram.player.skills[selected - 1].Name == "힐")
            {
                Console.Clear();
                UI.DisplayGameUI();
                Console.SetCursorPosition(3, 10);
                Console.WriteLine("힐 시전!");
                Console.SetCursorPosition(3, 12);
                Console.Write($"Hp {MainProgram.player.CurrentHp}");
                MainProgram.player.CurrentHp += 30;
                if (MainProgram.player.CurrentHp > MainProgram.player.Hp)
                {
                    MainProgram.player.CurrentHp = MainProgram.player.Hp;
                }
                Console.WriteLine($" -> {MainProgram.player.CurrentHp}");

                MainProgram.player.CurrentMp -= MainProgram.player.skills[selected - 1].MpConsume;
                Thread.Sleep(500);
            }
        }

        public static void EnemyPhase()
        {
            if (MainProgram.player.CurrentHp > 0)
            {
                for (int i = 0; i < monstersList.Count; i++)
                {
                    int saveCurrentHp = 0;
                    if (monstersList[i].CurrentHp <= 0)
                    {
                        continue;
                    }
                    Console.Clear();
                    UI.DisplayGameUI();
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.SetCursorPosition(32, 2);
                    Console.Write("[ 몬스터 턴 ]");
                    Console.ResetColor();

                    int monsDmg = CharacterBase.CalculateDamage(monstersList[i].Atk);
                    Console.SetCursorPosition(3, 9);
                    Console.WriteLine($"Lv.{monstersList[i].Lv} ");

                    Console.SetCursorPosition(3, 11);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine($" {monstersList[i].Name} ");
                    Console.ResetColor();
                    Console.SetCursorPosition(15, 11);
                    Console.Write($"의 공격!\n");

                    Console.SetCursorPosition(3, 13);
                    Console.WriteLine($"{MainProgram.player.Name}을 맞췄습니다. [데미지 : {monsDmg}]");
                    Console.SetCursorPosition(3, 15);
                    Console.WriteLine($"Lv.{MainProgram.player.Lv} {MainProgram.player.Name}\n");

                    saveCurrentHp = MainProgram.player.CurrentHp;
                    MainProgram.player.CurrentHp -= monsDmg;
                    if (MainProgram.player.CurrentHp <= 0)
                    {
                        Console.SetCursorPosition(30, 7);
                        Console.WriteLine($"HP {saveCurrentHp} -> 0");
                        Console.Clear();
                        UI.DisplayGameUI();
                        Console.SetCursorPosition(35, 2);
                        Console.WriteLine("[사망]");
                        Console.SetCursorPosition(30, 9);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Game Over...");
                        Console.ResetColor();
                        Console.SetCursorPosition(3, 27);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("아무키를 눌러 메인화면으로 되돌아 가십시오.");
                        Console.ResetColor();
                        Console.ReadLine();
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.SetCursorPosition(3, 17);
                        Console.WriteLine($"HP {saveCurrentHp} -> {MainProgram.player.CurrentHp}");
                        Console.SetCursorPosition(3, 27);
                        Console.WriteLine("다음");
                        Console.WriteLine();
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                Console.Clear();
                UI.DisplayGameUI();
                Console.SetCursorPosition(32, 2);
                Console.WriteLine("[플레이어 턴]");
                Console.SetCursorPosition(3, 27);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("아무키를 눌러 플레이어 차례로 진입하십시오");
                Console.ResetColor();
                Console.ReadKey();
                FightInfo();
            }
        }

        public static bool CheckAllMonstersDefeated()
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
            Console.SetCursorPosition(3, 28);
            int input = Utility.CheckValidInput(0, monstersList.Count);
            if (1 <= input && input <= monstersList.Count)
            {
                PlayerAttack(input, damage);
            }
            else
            {
                Console.SetCursorPosition(3, 27);
                Console.WriteLine("잘못된 입력입니다! 올바른 대상을 선택해주세요.");
                Thread.Sleep(300);
                BattleSkill();
            }
        }
    }
}