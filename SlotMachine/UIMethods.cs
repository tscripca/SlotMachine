using SlotMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    public static class UIMethods
    {
        public static void ChoiceNotValid()
        {
            Console.WriteLine("Selection not avaialable!Try again.");
        }
        public static void DisplayGameRules()
        {
            Console.WriteLine("\t\t\t=SLOT MACHINE=");
            Console.WriteLine($"This is a {Constants.SLOT_MACHINE_ROWS} by {Constants.SLOT_MACHINE_COLUMNS} slot machine.");
            Console.WriteLine("Insert credit amount then choose between three game types, Horizontal(H), Vertical(V) or Diagonal(D).");
            Console.WriteLine($"Each round you will be asked to bet either {Constants.BET_ONE_DOLLAR}, {Constants.BET_TWO_DOLLARS} up to {Constants.SLOT_MACHINE_ROWS} lines.");
            Console.WriteLine("Credit will be deducted from your balance proportionally with the number of lines you're playing, and " +
                $"will be added back into your account in case of a win for each matching line (e.g.match {Constants.BET_TWO_DOLLARS} then win ${Constants.BET_TWO_DOLLARS})");
            Console.WriteLine("Press any key to start!");
            Console.ReadKey();
            Console.Clear();
        }
       
        public static GameMode ChooseGameMode()
        {
            Console.WriteLine("Choose game mode: ");
            char userGameMode = Convert.ToChar(Console.ReadLine());  
            switch (userGameMode)
            {
                case 'h': gameModEnum = GameMode.horizontal; break;
                case 'v': gameModEnum = GameMode.vertical; break;
                case 'd': gameModEnum = GameMode.diagonal; break;
                default: UIMethods.ChoiceNotValid(); break;
            }
            return (GameMode)gameModeEnum;
        }
    }
}