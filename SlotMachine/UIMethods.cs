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
        public static void ChoiceNotValid()
        {
            Console.WriteLine("Selection not avaialable!Try again.");
        }
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
        
        public static int CheckBetAmount(int betAmount)
        {
            bool validateUserChoice = false;
            while (!validateUserChoice)
            {
                Console.WriteLine("How many lines would you like to play?: ");
                betAmount = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                if (betAmount >= Program.BET_ONE_DOLLAR && betAmount <= Program.SLOT_MACHINE_COLUMNS)
                {
                    validateUserChoice = true;
                }
                else
                {
                    validateUserChoice = false;
                    UIMethods.ChoiceNotValid();
                }
            }
            return betAmount;
        }

        //public static int InsufficientBalance(int userCredits)
        //{
        //    if (userCredits == 0)
        //    {
        //        Console.WriteLine("Your credit balance is $0.");
        //        Console.WriteLine("Keep playing? Y/N: ");
        //        Console.WriteLine();
        //        ConsoleKeyInfo userAnswer = Console.ReadKey();
        //        char keepPlaying = (char)userAnswer.KeyChar;
        //        while(keepPlaying == 'y' || keepPlaying == 'n')
        //        {
        //            if (keepPlaying == 'y')
        //            {
        //                userWantsToPlay;
        //            }
        //            if (keepPlaying == 'n')
        //            {
        //                !userWantsToPlay;
        //            }
        //            else
        //            {
        //                UIMethods.ChoiceNotValid();
        //            }
        //        }
        //    }
        //}
    }
}
