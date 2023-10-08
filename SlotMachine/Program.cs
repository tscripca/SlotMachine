﻿using System;
namespace SlotMachine
{
    enum GameMode
    {
        horizontal,
        vertical,
        diagonal
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            const int SLOT_MACHINE_ROWS = 3;
            const int SLOT_MACHINE_COLUMNS = 3;
            const int UPPPER_BOUND = 10;
            const int BET_ONE_LINE = 1;
            const int BET_TWO_LINES = 2;
            const int MINIMUM_FEE = 1;
            Random rng = new Random();
            int[,] slotMachine = new int[SLOT_MACHINE_ROWS, SLOT_MACHINE_COLUMNS];
            int lastColumnIndex = slotMachine.GetLength(1) - 1;
            Console.WriteLine("\t\t\t=SLOT MACHINE=");
            Console.WriteLine($"This is a {SLOT_MACHINE_ROWS} by {SLOT_MACHINE_COLUMNS} slot machine.");
            Console.WriteLine("Insert credit amount then choose between three game types, Horizontal(H), Vertical(V) or Diagonal(D).");
            Console.WriteLine($"Each round you will be asked to bet either {BET_ONE_LINE}, {BET_TWO_LINES} up to {SLOT_MACHINE_ROWS} lines.");
            Console.WriteLine("Credit will be deducted from your balance proportionally with the number of lines you're playing, and " +
                $"will be added back into your account in case of a win for each matching line (e.g.match {BET_TWO_LINES} then win ${BET_TWO_LINES})");
            Console.WriteLine("Press any key to start!");
            Console.ReadKey();
            Console.Clear();
            int remainingCredit = 0;
            int userCredits = 0;
            int betAmount = 0;
            bool autoPlay = true;
            char userGameMode = 'h';
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
                bool checkValue = false;
                while (!checkValue)
                {
                    Console.WriteLine($"\t\t\t\t\tCredits: ${userCredits}");
                    Console.WriteLine("Choose game mode(h, v, d): ");
                    ConsoleKeyInfo chooseMode = Console.ReadKey();
                    userGameMode = chooseMode.KeyChar;

                    if (userGameMode == 'h' || userGameMode == 'v' || userGameMode == 'd')
                    {
                        checkValue = true;
                    }
                }
                switch (userGameMode)
                {
                    case 'h': gameModEnum = GameMode.horizontal; break;
                    case 'v': gameModEnum = GameMode.vertical; break;
                    case 'd': gameModEnum = GameMode.diagonal; break;
                    default: Console.WriteLine("Not valid!"); break;
                }
                switch (gameModEnum)
                {
                    case GameMode.horizontal:
                        while (true)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"How many lines would you like to play?({BET_ONE_LINE} to {SLOT_MACHINE_ROWS}): ");
                            betAmount = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();
                            if (betAmount >= BET_ONE_LINE && betAmount <= slotMachine.GetLength(0))
                            {
                                Console.WriteLine("\t\t\tPlaying horizontal!");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Selection not avaialable!Try again.");
                            }
                        }
                        break;
                    case GameMode.vertical:
                        while (true)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"How many lines would you like to play?({BET_ONE_LINE} to {SLOT_MACHINE_ROWS}): ");
                            betAmount = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();
                            if (betAmount >= BET_ONE_LINE && betAmount <= slotMachine.GetLength(0))
                            {
                                Console.WriteLine("\t\t\tPlaying vertical!");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Selection not avaialable!Try again.");
                            }
                        }
                        break;
                    case GameMode.diagonal:
                        betAmount = BET_TWO_LINES;
                        Console.Clear();
                        while (true)
                        {
                            Console.WriteLine("\t\t\tPlaying diagonals!");
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
                if (userCredits == 0)
                {
                    Console.WriteLine("Your credit balance is $0.");
                    Console.WriteLine("Keep playing? Y/N: ");
                    ConsoleKeyInfo userAnswer = Console.ReadKey();
                    char keepPlaying = (char)userAnswer.KeyChar;
                    autoPlay = (keepPlaying == 'y');
                    if (keepPlaying == 'y')
                    {
                        autoPlay = true;
                        Console.Clear();
                    }
                    else if (keepPlaying == 'n')
                    {
                        autoPlay = false;
                        Console.Clear();
                    }
                }
            }
        }
    }
}