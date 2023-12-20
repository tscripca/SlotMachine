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
            int moneyWon = 0;
            int userCredits = 0;
            int remainingCredits = 0;
            bool userWantsToPlay = true;
            //UIMethods.DisplayGameRules();
            while (userWantsToPlay)
            {
                //program will come back here when no credit left or not enough to bet. - minimum fee is $1.
                while (remainingCredits < Constants.BET_ONE_DOLLAR)
                {
                    //the program will stop taking money when there's not enough credit to bet,
                    //so negative values are not allowed. 
                    if (remainingCredits < 0)
                    {
                        remainingCredits = userCredits;
                    }
                    Console.Write("Insert credit: $");
                    userCredits = Convert.ToInt32(Console.ReadLine());
                    remainingCredits += userCredits;
                    UIMethods.ClearScreen();
                    Console.WriteLine($"\t\t\t\tCredit balance: ${remainingCredits}");
                }
                GameMode gameModeEnum = UIMethods.ChooseGameMode();
                int betAmount = UIMethods.SetBetAmount(gameModeEnum);
                remainingCredits = UIMethods.MoneyCounter(remainingCredits, betAmount);
                //I need to check if user can afford to play the desired number of lines.
                if (betAmount > userCredits)
                {
                    UIMethods.NotEnoughCredit();
                    continue;
                }
                UIMethods.DisplayCreditBalance(remainingCredits);
                //grid generator
                int rndNum = 0;
                for (int rowIndex = 0; rowIndex < slotMachine.GetLength(0); rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < slotMachine.GetLength(1); columnIndex++)
                    {
                        rndNum = rng.Next(0, Constants.UPPPER_BOUND);
                        slotMachine[rowIndex, columnIndex] = rndNum;
                        Console.Write(rndNum + " ");
                    }
                    UIMethods.AddEmptyLine();
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
                UIMethods.GetWin(winningRowCount);
                moneyWon = UIMethods.PrintBalanceAfterRound(remainingCredits, winningRowCount);
                remainingCredits = moneyWon;
                //wait to reach zero credit then ask if the user wants to continue or stop playing.
                if (remainingCredits == 0)
                {
                    UIMethods.NotEnoughCredit();
                    Console.WriteLine("Keep playing? Y/N: ");
                    ConsoleKeyInfo userAnswer = Console.ReadKey();
                    char keepPlaying = (char)userAnswer.KeyChar;
                    UIMethods.AddEmptyLine();
                    userWantsToPlay = (keepPlaying == 'y');
                    UIMethods.ClearScreen();
                }
            }
        }
    }
}