using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG;

namespace TeamRPG
{
    internal class MainProgram
    {
        public static Character player;

        public static Monsters monsters;

        public static Minion minion;
        public static CanonMinion canonMinion;
        public static VoidMinion voidMinion;
        

        static void Main(string[] args)
        {
            GameDataSetting();
            DisplayGameIntro();
        }

        static void GameDataSetting()
        {
            // 캐릭터 정보 세팅
            player = new Character("Chad", "전사", 1, 10, 5, 100, 1500, "Dead", 50);

            // 아이템 정보 세팅


            //------정재호 몬스터/ 몬스터 리스트 정보세팅----------
            // 이름, 레벨,공격,체력            
            //minion = new Monster("미니언", 5, 15, 2);
            //canonMinion = new Monster("대포미니언", 8, 25, 5);
            //voidMinion = new Monster("공허충", 9, 10, 3);
            monsters = new Monsters();
            minion = new Minion("미니언", 5, 15, 2, "Dead");
            canonMinion = new CanonMinion("대포미니언", 8, 25, 5,"Dead");
            voidMinion = new VoidMinion("공허충", 9, 10, 3, "Dead");

            monsters.AddMonster2List(minion);
            monsters.AddMonster2List(canonMinion);
            monsters.AddMonster2List(voidMinion);
            //-------------------------------------
        }

        public static void DisplayGameIntro()
        {
            Console.Clear();

            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 전전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("1. 상태보기");
            Console.WriteLine("2. 인벤토리");
            //--------------정재호 전투추가--------------
            Console.WriteLine("3. 전투"); 
            //-------------------------------------------
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.WriteLine();


            int input = Utility.CheckValidInput(1, 3);

            if (input == 1)
            {
                Console.WriteLine();
                Console.WriteLine("상태보기 창으로 이동합니다.");
                Thread.Sleep(300);
                DisplayMyInfo();
            }
            else if (input == 2)
            {
                Console.WriteLine();
                Console.WriteLine("미구현");
                Thread.Sleep(300);
                DisplayGameIntro();
            }
            //--------------정재호 전투추가--------------
            else if (input == 3)
            {
                Console.WriteLine();
                Console.WriteLine("던전으로 이동합니다.");
                Thread.Sleep(300);
                Monsters.FightInfo();
            }
            //---------------------------------------------
            else
            {
                Console.WriteLine();
                Console.WriteLine("숫자를 다시 입력하세요");
                Console.WriteLine();
                Thread.Sleep(300);
                DisplayGameIntro();
            }
        }

        static void DisplayMyInfo()
        {
            Console.Clear();

            Console.WriteLine("상태보기");
            Console.WriteLine("캐릭터의 정보를 표시합니다.");
            Console.WriteLine();
            Console.WriteLine($"Lv.{player.Lv}");
            Console.WriteLine($"{player.Name}({player.Job})");
            Console.WriteLine($"공격력 :{player.Atk}");
            Console.WriteLine($"방어력 : {player.Def}");
            Console.WriteLine($"체력 : {player.Hp}");
            Console.WriteLine($"마나 : {player.Mp}");
            Console.WriteLine($"Gold : {player.Gold} G");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();

            int input = Utility.CheckValidInput(0, 0);

            if (input == 0)
            {
                Console.WriteLine();
                Console.WriteLine("메인화면으로 돌아갑니다..");
                Thread.Sleep(300);
                DisplayGameIntro();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("숫자를 다시 입력하세요");
                Console.WriteLine();
                Thread.Sleep(300);
                DisplayGameIntro();
            }
        }
    }
}