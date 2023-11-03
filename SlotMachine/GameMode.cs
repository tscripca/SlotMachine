using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{    enum GameMode
    {
        horizontal,
        vertical,
        diagonal
    }
    internal class GameMode
    {
        public static char ChooseGameMode(char userGameMode)
        {
            Console.Write("Choose game mode(h, v, d): ");
            ConsoleKeyInfo chooseMode = Console.ReadKey();
            userGameMode = chooseMode.KeyChar;
            Console.WriteLine();
            Console.Clear();
            bool validateGameMode = false;
            while (!validateGameMode)
            {
                switch (userGameMode)
                {
                    case 'h': gameModEnum = GameMode.horizontal; break;
                    case 'v': gameModEnum = GameMode.vertical; break;
                    case 'd': gameModEnum = GameMode.diagonal; break;
                    default: UIMethods.ChoiceNotValid(); break;
                }
            }
            return gameModeEnum; ;
        }
    }
}
