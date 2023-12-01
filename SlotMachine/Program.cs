using SlotMachine;
using System;

namespace SlotMachine
{    
    public static class Program
    {       
        static void Main(string[] args)
        {
            int[,] slotMachine = new int[Constants.SLOT_MACHINE_ROWS, Constants.SLOT_MACHINE_COLUMNS];
            
            Random rng = new Random();           
            int userCredits = 0;
            bool userWantsToPlay = true;
            int remainingCredit = 0;

            //UIMethods.DisplayGameRules();

            while (userWantsToPlay)
            {
                //program will come back here when no credit left or not enough to bet. - minimum fee is $1.
                while (remainingCredit < Constants.BET_ONE_DOLLAR)
                {
                    //the program will stop taking money when there's not enough credit to bet, so negative values are not allowed.                    
                    if (remainingCredit < 0)
                    {
                        remainingCredit = userCredits;
                    }
                    Console.Write("Insert credit: $");
                    remainingCredit = Convert.ToInt32(Console.ReadLine());
                    userCredits += remainingCredit;
                    Console.Clear();
                    Console.WriteLine($"\t\t\t\tCredit balance: ${userCredits}");
                }

                GameMode gameModeEnum = UIMethods.ChooseGameMode();
                int betAmount = UIMethods.SetBetAmount(gameModeEnum);
                
                remainingCredit = userCredits - betAmount;
                //I need to check if user can afford to play the desired number of lines.
                if (betAmount > userCredits)
                {
                    Console.WriteLine("Not enough credit!");
                    continue;
                }
                int rndNum = 0;
                //grid generator
                for (int rowIndex = 0; rowIndex < slotMachine.GetLength(0); rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < slotMachine.GetLength(1); columnIndex++)
                    {
                        rndNum = rng.Next(0, Constants.UPPPER_BOUND);
                        slotMachine[rowIndex, columnIndex] = rndNum;
                        Console.Write(rndNum + " ");
                    }
                    Console.WriteLine();
                }
                int winningRowCount = 0;
                if (gameModeEnum == GameMode.horizontal)
                {
                    LogicMethods.CheckHorizontalWin(betAmount, slotMachine);                   
                }
                if (gameModeEnum == GameMode.vertical)
                {
                    LogicMethods.CheckVerticalWin(betAmount, slotMachine);                    
                }
                if (gameModeEnum == GameMode.diagonal)
                {
                    LogicMethods.CheckDiagonalWin(slotMachine);                    
                }

                Console.WriteLine($"\t\t\tYou've won ${winningRowCount} this round.");
                userCredits = remainingCredit + winningRowCount;
                Console.WriteLine($"\t\t\t\tCredit balance: {userCredits}");

                //wait to reach zero credit then ask if the user wants to continue or stop playing.
                if (userCredits == 0)
                {
                    Console.WriteLine("Your credit balance is $0.");
                    Console.WriteLine("Keep playing? Y/N: ");
                    ConsoleKeyInfo userAnswer = Console.ReadKey();
                    char keepPlaying = (char)userAnswer.KeyChar;
                    Console.WriteLine();
                    userWantsToPlay = (keepPlaying == 'y');
                    Console.Clear();
                }
            }
        }    
    }
}