using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
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
                    bool parseSuccess = int.TryParse(input, out var ret);
                    if (!parseSuccess)
                    {
                        Console.SetCursorPosition(3, 27);
                        Console.WriteLine("숫자를 입력해주세요:                           ");
                        Console.SetCursorPosition(24, 27);
                        continue;
                    }
                    return ret;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
        }

        public static void SaveGameData()
        {
            string fileName = "_playerData.json";

            string userDocumentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            string filePath = Path.Combine(userDocumentsFolder, fileName);

            var options = new JsonSerializerOptions { WriteIndented = true };

            string playersData = JsonSerializer.Serialize(MainProgram.player, options);

            playersData = Regex.Unescape(playersData);

            File.WriteAllText(filePath, playersData);
        }

        public static void LoadGameData()
        {
            string fimeName = "_playerData.json";
            string userDocumentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(userDocumentsFolder, fimeName);
            if(File.Exists(filePath))
            {
                MainProgram.isCreate = true;
                string playerJson = File.ReadAllText(filePath);
                playerJson = Regex.Unescape(playerJson);
                Character loadedCharacter = JsonSerializer.Deserialize<Character>(playerJson);
                MainProgram.player = loadedCharacter;
            }
            else
            {
                Console.WriteLine("데이터가 없습니다.");
                Thread.Sleep(500);
                MainProgram.GameDataSetting();
            }
        }
    }
}