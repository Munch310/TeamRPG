using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Diagnostics;
//using System.Reflection;
using TeamRPG;

namespace TeamRPG
{
    public class Utility
    {
        public static int CheckValidInput(int min, int max)
        {
            while (true)
            {

                string input = Console.ReadLine();
                try
                {
                    // ------문현우 try catch----------
                    // 입력된 문자열을 정수로 변환 -> t, 정수 값 -> ret
                    // 실패 -> f , FormatException 발생.
                    bool parseSuccess = int.TryParse(input, out var ret);
                    if (!parseSuccess)
                    {
                        // throw new FormatException();
                        // throw new OverflowException();
                        throw new FormatException("알맞은 숫자를 다시 입력하세요.");
                    }
                    return ret;
                }
                catch (FormatException ex)
                {
                    // 현재 메서드를 불러오려 했으나, CheckValidInput 호출.
                    // string currentMethod = MethodBase.GetCurrentMethod().Name;
                    // Console.WriteLine(currentMethod);

                    // try에서 발생한 오류를 catch 블록에서 처리.
                    
                    Console.WriteLine("알맞은 숫자가 아닙니다.\n" + ex.Message);
                    // break;
                    // -------------------------------------
                }
            }
        }
    }
}
