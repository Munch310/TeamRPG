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
        private static Character player;

        static void Main(string[] args)
        {
            GameDataSetting();
            DisplayGameIntro();
        }

        static void GameDataSetting()
        {
            // 캐릭터 정보 세팅
            player = new Character("Chad", "전사", 1, 10, 5, 100, 1500);

            // 아이템 정보 세팅
        }

        static void DisplayGameIntro()
        {
            Console.Clear();

            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 전전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("1. 상태보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 전투");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");


            int input = Utility.CheckValidInput(1, 3);

            if (input == 1)
            {
                Console.WriteLine("상태보기 창으로 이동합니다.");
                Thread.Sleep(300);
                DisplayMyInfo();
            }
            else if (input == 2)
            {
                Console.WriteLine("미구현");
                Thread.Sleep(300);
                DisplayGameIntro();
            }
            else if (input == 3)
            {
                Console.WriteLine("전투 창으로 이동합니다.");
                Thread.Sleep(300);
                FightEnemy();
            }
            else
            {
                DisplayGameIntro();
            }


        }

        static void DisplayMyInfo()
        {
            Console.Clear();

            Console.WriteLine("상태보기");
            Console.WriteLine("캐릭터의 정보르 표시합니다.");
            Console.WriteLine();
            Console.WriteLine($"Lv.{player.Level}");
            Console.WriteLine($"{player.Name}({player.Job})");
            Console.WriteLine($"공격력 :{player.Atk}");
            Console.WriteLine($"방어력 : {player.Def}");
            Console.WriteLine($"체력 : {player.Hp}");
            Console.WriteLine($"Gold : {player.Gold} G");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");

            int input = Utility.CheckValidInput(0, 0);
            try
            {
                if (input == 0)
                {
                    Console.WriteLine("메인화면으로 돌아갑니다..");
                    Thread.Sleep(300);
                    DisplayGameIntro();
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("알맞은 숫자를 다시 입력하세요");
                Console.ReadKey();
                DisplayGameIntro();
            }
        }

        static void FightEnemy()
        {

        }
    }
}