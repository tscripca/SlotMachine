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
            char userchoice = ' ';
            
            GameMode gameModeEnum = GameMode.horizontal;

            bool success = char.TryParse(userchoice, out );

            Console.WriteLine("Choose game mode: ");
            char userGameMode = Convert.ToChar(Console.ReadLine());
            switch (userGameMode)
            {
                case 'h': gameModeEnum = GameMode.horizontal; break;
                case 'v': gameModeEnum = GameMode.vertical; break;
                case 'd': gameModeEnum = GameMode.diagonal; break;
                default: Console.WriteLine("Selection not avaialable!Try again.");break; 
            }
            return (GameMode)gameModeEnum;
        }
    }
    //returns betAmount into the main program
    public static int GetBetAmount()
    {

        int betAmount = 0;
        switch (userMode)
        {
            case (char)GameMode.horizontal:
                Console.WriteLine("How many lines would you like to play?: ");
                betAmount = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                break;
            case (char)GameMode.vertical:
                Console.WriteLine("How many lines would you like to play?: ");
                betAmount = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                break;
            case (char)GameMode.diagonal:
                betAmount = Constants.BET_TWO_DOLLARS;
                Console.Clear();
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
        return betAmount;
    }
}