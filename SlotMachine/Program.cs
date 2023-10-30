using SlotMachine;
using System;
using System.Net.Security;

namespace slotMachine
{
    enum GameMode
    {
        horizontal,
        vertical,
        diagonal
    }    
    public static class Program
    {
        public static int[,] slotMachine = new int[SLOT_MACHINE_ROWS, SLOT_MACHINE_COLUMNS];
        public const int SLOT_MACHINE_ROWS = 3;
        public const int SLOT_MACHINE_COLUMNS = 3;
        public const int UPPPER_BOUND = 10;
        public const int BET_ONE_DOLLAR = 1;
        public const int BET_TWO_DOLLARS = 2;
        public const int MINIMUM_FEE = 1;
        public static int userCredits = 0;
        public static bool autoPlay = true;
        public static int betAmount = 0;
        public const int lowerBetBound = BET_ONE_DOLLAR;
        public static int upperBetBound = slotMachine.GetLength(0);
        static void Main(string[] args)
        {
            Random rng = new Random();            
            int lastColumnIndex = slotMachine.GetLength(1) - 1;            
            int upperBetBound = slotMachine.GetLength(0);
            int remainingCredit = 0;
            char userGameMode = 'h';
            
        UIMethods.DisplayGameRules();

            while (autoPlay)
            {
                //program will come back here when no credit left or not enough to bet.
                while (remainingCredit < MINIMUM_FEE)
                {
                    //I want to store my current credit even when there is not enough credit to play, and then add more credit on top of it,
                    //so negative values are not allowed.                    
                    if (remainingCredit < 0)
                    {
                        remainingCredit = userCredits;
                    }
                    Console.Write("Insert credit: ");
                    remainingCredit = Convert.ToInt32(Console.ReadLine());
                    userCredits += remainingCredit;
                    Console.Clear();
                }
                GameMode gameModEnum = GameMode.horizontal;
                UIMethods.ChooseGameMode(userGameMode);
               
                //this will validate the user input
                switch (userGameMode)
                {
                    case 'h': gameModEnum = GameMode.horizontal; break;
                    case 'v': gameModEnum = GameMode.vertical; break;
                    case 'd': gameModEnum = GameMode.diagonal; break;
                    default: Console.WriteLine("Not valid!"); continue;
                }
                switch (gameModEnum)
                {
                    case GameMode.horizontal:
                        UIMethods.HowManyLines(betAmount);
                        LogicMethods.CheckBetAmount();
                        break;
                    case GameMode.vertical:
                        
                        userBetLines = LogicMethods.CheckBetAmount(lowerBetBound, upperBetBound);
                        break;
                    case GameMode.diagonal:
                        int betAmount = BET_TWO_DOLLARS;
                        Console.Clear();
                        while (true)
                        {
                            break;
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
                remainingCredit = userCredits - betAmount;
                //I need to check if user can afford to play the desired number of lines.
                if (betAmount > userCredits)
                {
                    Console.WriteLine("Not enough credit!");
                    continue;
                }
                int rndNum = 0;
                for (int rowIndex = 0; rowIndex < slotMachine.GetLength(0); rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < slotMachine.GetLength(1); columnIndex++)
                    {
                        rndNum = rng.Next(0, UPPPER_BOUND);
                        slotMachine[rowIndex, columnIndex] = rndNum;
                        Console.Write(rndNum + " ");
                    }
                    Console.WriteLine();
                }
                int winningRowCount = 0;
                if (gameModEnum == GameMode.horizontal)
                {
                    for (int rowIndex = 0; rowIndex < betAmount; rowIndex++)
                    {
                        bool numbersMatch = true;
                        for (int columnIndex = 0; columnIndex < slotMachine.GetLength(1); columnIndex++)
                        {
                            if (slotMachine[rowIndex, 0] != slotMachine[rowIndex, columnIndex])
                            {
                                numbersMatch = false;
                                break;
                            }
                        }
                        if (numbersMatch)
                        {
                            winningRowCount++;
                        }
                    }
                }
                if (gameModEnum == GameMode.vertical)
                {
                    for (int columnIndex = 0; columnIndex < betAmount; columnIndex++)
                    {
                        bool numbersMatch = true;
                        for (int rowIndex = 0; rowIndex < slotMachine.GetLength(0); rowIndex++)
                        {
                            if (slotMachine[0, columnIndex] != slotMachine[rowIndex, columnIndex])
                            {
                                numbersMatch = false;
                                break;
                            }
                        }
                        if (numbersMatch)
                        {
                            winningRowCount++;
                        }
                    }
                }
                if (gameModEnum == GameMode.diagonal)
                {
                    int matchingDiagonalNumbers = 0;
                    //checking the 1st diagonal
                    for (int rowIndex = 0; rowIndex < slotMachine.GetLength(0); rowIndex++)
                    {
                        bool numbersMatch = true;
                        for (int columnIndex = rowIndex; columnIndex <= rowIndex; columnIndex++)
                        {
                            if (slotMachine[0, 0] != slotMachine[rowIndex, columnIndex])
                            {
                                numbersMatch = false;
                                break;
                            }
                        }
                        if (numbersMatch)
                        {
                            matchingDiagonalNumbers++;
                        }
                    }
                    if (matchingDiagonalNumbers >= slotMachine.GetLength(1))
                    {
                        winningRowCount++;
                    }
                    matchingDiagonalNumbers = 0;
                    //checking 2nd diagonal
                    for (int rowIndex = 0; rowIndex < slotMachine.GetLength(0); rowIndex++)
                    {
                        bool numbersMatch = true;
                        int randomValue = 0;
                        for (int columnIndex = lastColumnIndex - rowIndex; columnIndex >= randomValue; columnIndex--)
                        {
                            if (slotMachine[0, lastColumnIndex] != slotMachine[rowIndex, columnIndex])
                            {
                                numbersMatch = false;
                            }
                            randomValue = slotMachine.GetLength(1);
                        }
                        if (numbersMatch)
                        {
                            matchingDiagonalNumbers++;
                        }
                    }
                    if (matchingDiagonalNumbers >= slotMachine.GetLength(1))
                    {
                        winningRowCount++;
                    }
                }
                Console.WriteLine($"\t\t\tYou've won ${winningRowCount} this round.");
                userCredits = remainingCredit + winningRowCount;

                //wait to reach zero credit then ask if the user wants to continue or stop playing.
                UIMethods.CheckUserCreditBalance();
                if (UIMethods.MakeDecision() == true)
                {
                    autoPlay = true;
                }
                else
                {
                    break;
                }
            }
        }//main method    
    }
}