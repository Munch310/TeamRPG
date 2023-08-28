using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamRPG
{
    public class Utility
    {
        public static int CheckValidInput(int min, int max)
        {
            //while (true)
            //{
            //    string input = Console.ReadLine();

            //    bool parseSuccess = int.TryParse(input, out var ret);
            //    if (parseSuccess)
            //    {
            //        if (ret >= min && ret <= max)
            //            return ret;
            //    }
            //    Console.WriteLine();
            //    Console.WriteLine("잘못된 입력입니다.");
            //    Console.WriteLine("알맞은 숫자를 다시 입력하세요");
            //    Console.WriteLine();
            //}

            while (true)
            {
                string input = Console.ReadLine();
                try
                {
                    bool parseSuccess = int.TryParse(input, out var ret);
                    if (parseSuccess)
                    {
                        return ret;
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine("알맞은 숫자를 다시 입력하세요");
                    Console.ReadKey();
                }
            }
        }
    }
}
