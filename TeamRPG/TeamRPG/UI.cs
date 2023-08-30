using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TeamRPG
{
    //------문현우 UI 구현 메서드----------
    public class UI
    {
        public static void DisplayGameUI()
        {
            Console.SetWindowSize(80, 35);
            Console.WriteLine("┌─────────────────────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│                                                                             │");
            Console.WriteLine("│                                                                             │");
            Console.WriteLine("│                                                                             │");
            Console.WriteLine("├─────────────────────────────────────────────────────────────────────────────┤");
            Console.WriteLine("│                                                                             │");
            Console.WriteLine("│                                                                             │");
            Console.WriteLine("│                                                                             │");
            Console.WriteLine("│                                                                             │");
            Console.WriteLine("│                                                                             │");
            Console.WriteLine("│                                                                             │");
            Console.WriteLine("│                                                                             │");
            Console.WriteLine("│                                                                             │");
            Console.WriteLine("│                                                                             │");
            Console.WriteLine("│                                                                             │");
            Console.WriteLine("│                                                                             │");
            Console.WriteLine("│                                                                             │");
            Console.WriteLine("│                                                                             │");
            Console.WriteLine("│                                                                             │");
            Console.WriteLine("│                                                                             │");
            Console.WriteLine("│                                                                             │");
            Console.WriteLine("├─────────────────────────────────────────────────────────────────────────────┤");
            Console.WriteLine("│                                                                             │");
            Console.WriteLine("│                                                                             │");
            Console.WriteLine("│                                                                             │");
            Console.WriteLine("├─────────────────────────────────────────────────────────────────────────────┤");
            Console.WriteLine("│                                                                             │");
            Console.WriteLine("│                                                                             │");
            Console.WriteLine("│                                                                             │");
            Console.WriteLine("└─────────────────────────────────────────────────────────────────────────────┘");

            Console.SetCursorPosition(32, 2);
            Console.WriteLine("TEAM RPG GAME");
        }
        
    }
}
