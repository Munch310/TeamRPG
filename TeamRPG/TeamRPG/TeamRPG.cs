using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG;
using System.Text.Json;

namespace TeamRPG
{
    internal class MainProgram
    {
        public static Character player;
        public static Monsters monsters;
        public static List<CharacterBase> monstersList;
        public static Minion minion;
        public static CanonMinion canonMinion;
        public static VoidMinion voidMinion;

        public static Dictionary<string, Character> JobsDic = new Dictionary<string, Character>();

        static string getName = "";
        public static bool isCreate = false; 

        static void Main(string[] args)
        {
            Utility.LoadGameData();
            DisplayGameIntro();
        }

        public static void GameDataSetting()
        {
            JobsDic.Add("전사", new Character("Chad", "전사", 1, 10, 5, 100, 1500, "Dead", 50));
            JobsDic.Add("마법사", new Character("Deliki", "마법사", 1, 8, 3, 80, 1500, "Dead", 80));
        }


        public static void DisplayCreateCharacter()
        {
            bool check = true;
            do
            {
                if (getName == null || getName == "")
                {
                    Console.SetCursorPosition(3, 23);
                    Console.WriteLine("당신의 이름은 무엇인가요? ");
                    Console.SetCursorPosition(3, 27);
                    getName = Console.ReadLine();
                }
                else
                {
                    check = false;
                }
            } 
            while (check);

            Console.SetCursorPosition(3, 27);
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(3, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth / 2));
            Console.SetCursorPosition(3, currentLineCursor - 1);
            Console.SetCursorPosition(3, 23);
            Console.SetCursorPosition(3, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth / 2));
            Console.SetCursorPosition(3, currentLineCursor - 1);
            Console.SetCursorPosition(3, 23);
            Console.WriteLine($"당신은 {getName} 이군요.");
            Thread.Sleep(2000);

            DisplayGetJob();
        }

        public static void DisplayGetJob()
        {
            Console.SetCursorPosition(3, 27);
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(3, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth / 2));
            Console.SetCursorPosition(3, currentLineCursor - 1);

            Console.SetCursorPosition(3, 23);
            Console.WriteLine("당신의 직업을 선택해주세요. 전사 [1] | 마법사 [2] ");
            Console.SetCursorPosition(3, 27);
            int input = Utility.CheckValidInput(1, 2);
            if (input == 1)//전사
            {
                player = new Character(JobsDic["전사"].Name, JobsDic["전사"].Job, JobsDic["전사"].Lv, JobsDic["전사"].Atk, JobsDic["전사"].Def, JobsDic["전사"].Hp, JobsDic["전사"].Gold, JobsDic["전사"].IsDead, JobsDic["전사"].Mp);
                player.AddSkill(SkillList.alphaStrike);
                player.AddSkill(SkillList.doubleStrike);
            }
            else if (input == 2)//마법사
            {
                player = new Character(JobsDic["마법사"].Name, JobsDic["마법사"].Job, JobsDic["마법사"].Lv, JobsDic["마법사"].Atk, JobsDic["마법사"].Def, JobsDic["마법사"].Hp, JobsDic["마법사"].Gold, JobsDic["마법사"].IsDead, JobsDic["마법사"].Mp);
                player.AddSkill(SkillList.thunderVolt);
                player.AddSkill(SkillList.heal);
            }
            else
            {
                DisplayGetJob();
            }
            player.Name = getName;
            isCreate = true;
            Console.Clear();
            UI.DisplayGameUI();
        }

        public static void DisplayGameIntro()
        {
            Console.Clear();

            monsters = new Monsters();
            int monsterCount = 3;
            for (int i = 0; i < monsterCount; i++)
            {
                Random rand = new Random();
                int temp = rand.Next(1, 4);
                if (temp == 1)
                {
                    monsters.AddMonster2List(new Minion("미니언", 5, 15, 2, "Dead"));
                }
                else if (temp == 2)
                {
                    monsters.AddMonster2List(new CanonMinion("대포미니언", 8, 25, 5, "Dead"));
                }
                else if (temp == 3)
                {
                    monsters.AddMonster2List(new VoidMinion("공허충", 9, 10, 3, "Dead"));
                }
            }

            monstersList = Monsters.GetMonstersList();
            UI.DisplayGameUI();

            if(isCreate == false)
            { 
                DisplayCreateCharacter(); 
            }
            
            UI.DIsplayGameTitle();

            Console.SetCursorPosition(2, 23);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" [0] ");
            Console.ResetColor();
            Console.Write("게임 종료 ");
            Console.SetCursorPosition(24, 23);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" [1] ");
            Console.ResetColor();
            Console.Write("상태보기 ");
            Console.SetCursorPosition(48, 23);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" [2] ");
            Console.ResetColor();
            Console.Write("전투 ");
            Console.SetCursorPosition(68, 23);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" [3] ");
            Console.ResetColor();
            Console.Write("여관 ");
            Console.SetCursorPosition(3, 27);
            Console.Write("숫자를 입력해주세요: ");

            int input = Utility.CheckValidInput(1, 3);

            if (input == 0)
            {
                Console.SetCursorPosition(3, 27);
                Console.WriteLine("TEAM RPG를 종료합니다.");
                Thread.Sleep(300);
                Environment.Exit(0);
            }
            else if (input == 1)
            {
                Console.SetCursorPosition(3, 27);
                Console.WriteLine("상태창으로 이동합니다.");
                Thread.Sleep(300);
                DisplayMyInfo();
            }
            else if (input == 2)
            {
                Console.SetCursorPosition(3, 27);
                Console.WriteLine("던전으로 이동합니다.");
                Thread.Sleep(300);
                Monsters.FightInfo();
            }
            else if (input == 3)
            {
                Console.SetCursorPosition(3, 27);
                Console.WriteLine("여관으로 이동합니다.");
                Thread.Sleep(300);
                GetRestInfo();
                
            }
            else
            {
                Console.SetCursorPosition(3, 27);
                Console.WriteLine("숫자를 다시 입력하세요.");
                Thread.Sleep(500);
                DisplayGameIntro();
            }
        }

        static void DisplayMyInfo()
        {
            Console.Clear();

            UI.DisplayGameUI();
            Console.SetCursorPosition(32, 2);
            Console.WriteLine("[상태보기]");
            Console.SetCursorPosition(24, 6);
            Console.WriteLine("캐릭터의 정보를 표시합니다.");
            Console.SetCursorPosition(2, 23);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" [0] ");
            Console.ResetColor();
            Console.Write("나가기");
            Console.SetCursorPosition(6, 7);
            Console.Write($"Lv.{player.Lv}");
            Console.SetCursorPosition(6, 9);
            Console.ForegroundColor= ConsoleColor.Magenta;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine($" {player.Name} ");
            Console.ResetColor();
            Console.SetCursorPosition(15, 9);
            Console.Write($"({player.Job})");
            Console.SetCursorPosition(6, 11);
            Console.WriteLine($"공격력 :{player.Atk}");
            Console.SetCursorPosition(6, 13);
            Console.WriteLine($"방어력 : {player.Def}");
            Console.SetCursorPosition(6, 15);
            Console.WriteLine($"체력 : {player.CurrentHp} / {player.Hp}");
            Console.SetCursorPosition(6, 17);
            Console.WriteLine($"마나 : {player.CurrentMp} / {player.Mp}");
            Console.SetCursorPosition(6, 19);
            Console.WriteLine($"Gold : {player.Gold} G");

            Console.SetCursorPosition(3, 27);
            Console.Write("숫자를 입력해주세요: ");
            int input = Utility.CheckValidInput(0, 0);

            if (input == 0)
            {
                Console.SetCursorPosition(3, 27);
                Console.WriteLine("메인화면으로 돌아갑니다..");
                Thread.Sleep(300);
                DisplayGameIntro();
            }
            else
            {
                Console.SetCursorPosition(3, 27);
                Console.WriteLine("숫자를 다시 입력하세요");
                Thread.Sleep(300);
                DisplayGameIntro();
            }
        }

        static void GetRestInfo()
        {
            Console.Clear();
            UI.DisplayGameUI();
            Console.SetCursorPosition(35, 2);
            Console.WriteLine("[여관]");
            Console.SetCursorPosition(10, 6);
            Console.WriteLine("휴식을 취할 경우, 500G를 사용하여 체력과 마나를 50 회복합니다."); // 골드 사용
            Console.SetCursorPosition(17, 9);
            Console.WriteLine("또한, 현재 플레이어 데이터가 저장됩니다.");
            Console.SetCursorPosition(6, 11);
            Console.Write($"Lv.{player.Lv}");
            Console.SetCursorPosition(6, 13);
            Console.WriteLine($"{player.Name}({player.Job})");
            Console.SetCursorPosition(6, 15);
            Console.WriteLine($"체력 : {player.CurrentHp} / {player.Hp}");
            Console.SetCursorPosition(6, 17);
            Console.WriteLine($"마나 : {player.CurrentMp} / {player.Mp}");
            Console.SetCursorPosition(6, 19);
            Console.WriteLine($"Gold : {player.Gold} G");
            Console.SetCursorPosition(2, 23);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" [0] ");
            Console.ResetColor();
            Console.Write("나가기");
            Console.SetCursorPosition(24, 23);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" [1] ");
            Console.ResetColor();
            Console.Write("휴식 취하기(500G)");
            Console.SetCursorPosition(3, 27);
            Console.Write("숫자를 입력해주세요: ");

            int input = Utility.CheckValidInput(0, 1);
            if (input == 0)
            {
                Console.SetCursorPosition(3, 27);
                Console.WriteLine("메인화면으로 돌아갑니다..");
                Thread.Sleep(300);
                DisplayGameIntro();
            }
            else if (input == 1)
            {
                if (player.Gold < 500)
                {
                    Console.Clear();
                    UI.DisplayGameUI();
                    Console.SetCursorPosition(35, 2);
                    Console.WriteLine("[여관]");
                    Console.SetCursorPosition(3, 10);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("골드가 부족합니다!");
                    Console.ResetColor();
                    Console.SetCursorPosition(3, 12);
                    Console.WriteLine("아무 키를 눌러 돌아가기");
                    Console.ReadLine();
                    GetRestInfo();
                }
                else
                {
                    Console.Clear();
                    UI.DisplayGameUI();
                    Console.SetCursorPosition(3, 27);
                    Console.WriteLine("휴식을 취합니다..");
                    Console.SetCursorPosition(3, 10);
                    Console.Write($"Gold {player.Gold} -> {player.Gold -= 500}");
                    Console.SetCursorPosition(3, 12);
                    Console.Write($"Hp {player.CurrentHp}");
                    player.CurrentHp += 50;

                    if (player.CurrentHp > player.Hp)
                    {
                        player.CurrentHp = player.Hp;
                    }
                    Console.WriteLine($" -> {player.CurrentHp}");

                    Console.SetCursorPosition(3, 14);
                    Console.Write($"Mp {player.CurrentMp}");
                    player.CurrentMp += 50;
                    if (player.CurrentMp > player.Mp)
                    {
                        player.CurrentMp = player.Mp;
                    }
                    Console.WriteLine($" -> {player.CurrentMp}");
                    Console.SetCursorPosition(3, 14);
                    Thread.Sleep(500);
                    Utility.SaveGameData();
                    Console.SetCursorPosition(3, 27);
                    Console.WriteLine("저장이 완료되었습니다.");
                    Thread.Sleep(500);
                    DisplayGameIntro();
                }
            }
            else
            {
                Console.SetCursorPosition(3, 27);
                Console.WriteLine("숫자를 다시 입력하세요");
                Thread.Sleep(300);
                DisplayGameIntro();
            }
        }
    }
}