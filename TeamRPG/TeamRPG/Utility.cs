using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    // ------문현우 try catch----------------
                    // 입력된 문자열을 정수로 변환 -> t, 정수 값 -> ret
                    // 실패 -> f , FormatException 발생.
                    bool parseSuccess = int.TryParse(input, out var ret);
                    if (!parseSuccess)
                    {
                        Console.SetCursorPosition(3, 27);
                        Console.WriteLine("숫자를 입력해주세요:         "); // 오류 메시지 표시 후 공백 문자로 덮어쓰기
                        Console.SetCursorPosition(24, 27);
                        continue; // 다시 입력 받기 위해 반복문 처음으로 돌아감
                    }
                    return ret;
                }
                catch (FormatException ex)
                {
                    // try에서 발생한 오류를 catch 블록에서 처리.
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
        }
    }
}