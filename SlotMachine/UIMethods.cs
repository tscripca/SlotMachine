using slotMachine;
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
            Console.WriteLine($"This is a {Program.SLOT_MACHINE_ROWS} by {Program.SLOT_MACHINE_COLUMNS} slot machine.");
            Console.WriteLine("Insert credit amount then choose between three game types, Horizontal(H), Vertical(V) or Diagonal(D).");
            Console.WriteLine($"Each round you will be asked to bet either {Program.BET_ONE_DOLLAR}, {Program.BET_TWO_DOLLARS} up to {Program.SLOT_MACHINE_ROWS} lines.");
            Console.WriteLine("Credit will be deducted from your balance proportionally with the number of lines you're playing, and " +
                $"will be added back into your account in case of a win for each matching line (e.g.match {Program.BET_TWO_DOLLARS} then win ${Program.BET_TWO_DOLLARS})");
            Console.WriteLine("Press any key to start!");
            Console.ReadKey();
            Console.Clear();
        }
        public static int ChooseGameMode(char userGameMode)
        {
            Console.WriteLine($"\t\t\t\t\tCredits: ${Program.userCredits}");
            Console.Write("Choose game mode(h, v, d): ");
            ConsoleKeyInfo chooseMode = Console.ReadKey();
            userGameMode = chooseMode.KeyChar;
            Console.WriteLine();
            Console.Clear();
            return userGameMode;
        }
        public static int HowManyLines(int betAmount)
        {
            Console.WriteLine("How many lines would you like to play?: ");
            betAmount = Convert.ToInt32(Console.ReadLine());
            return betAmount;
        }       
        public static void CheckUserCreditBalance()
        {
            if (Program.userCredits == 0)
            {
                Console.WriteLine("Your credit balance is $0.");
                Console.WriteLine("Keep playing? Y/N: ");               
            }           
        }
        public static bool MakeDecision()
        {
            if (Program.autoPlay)
            {
                ConsoleKeyInfo userAnswer = Console.ReadKey();
                char keepPlaying = (char)userAnswer.KeyChar;
                Program.autoPlay = (keepPlaying == 'y');
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
}
