using System;

namespace SlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int SLOT_MACHINE_ROWS = 3;
            const int SLOT_MACHINE_COLUMNS = 3;
            const int MINIMUM_FEE = 1;
            const int PLAY_HORIZONTAL = 1;
            const int PLAY_VERTICAL = 2;
            const int PLAY_DIAGONALS = 3;
            const int BET_ONE_LINE = 1;
            const int BET_TWO_LINES = 2;

            bool autoPlay = true;
            int credits = 0;

            Random rng = new Random();
            int[,] slotMachine = new int[SLOT_MACHINE_ROWS, SLOT_MACHINE_COLUMNS];

            int lastColumnIndex = slotMachine.GetLength(1) - 1;

            int betAmount = 0;

            Console.WriteLine("\t\t\t=SLOT MACHINE=");
            Console.WriteLine($"This is a {SLOT_MACHINE_ROWS} by {SLOT_MACHINE_COLUMNS} slot machine.");
            Console.WriteLine("In this game you will be asked to insert an mount of credit of your choice.");
            Console.WriteLine("After this you will have to choose between three game types, Horizontal, Vertical or Diagonals.");
            Console.WriteLine($"On each game type you can bet on {BET_ONE_LINE}, {BET_TWO_LINES} up to {SLOT_MACHINE_ROWS} lines.");
            Console.WriteLine("Credit will be deducted from your account, proportionally with number of lines you've bet on, and " +
                $"will be added back into your account in case of a win, at the same ratio.(e.g. bet {SLOT_MACHINE_ROWS} lines and match only {BET_TWO_LINES} lines then only " +
                $"${BET_TWO_LINES} will be added to your account.)");
            Console.WriteLine("Press any key to start!");
            Console.ReadKey();
            Console.Clear();   

            while (autoPlay)
            {
                Console.Write("Insert credit: ");
                int totalCreditBalance = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                Console.WriteLine($"\t\t\t${totalCreditBalance} have been added.");
                credits += totalCreditBalance;

                while (totalCreditBalance >= MINIMUM_FEE)
                {
                    Console.WriteLine($"\t\t\tCredit balance: ${credits}");
                    Console.WriteLine("Choose:");
                    Console.WriteLine("1 - horizontal");
                    Console.WriteLine("2 - vertical");
                    Console.WriteLine("3 - diagonals");
                    int userChooseGame = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();

                    while (userChooseGame < 0 || userChooseGame > slotMachine.GetLength(0))
                    {
                        Console.WriteLine("Selection not available! Try again.");
                        Console.WriteLine("1 - horizontal");
                        Console.WriteLine("2 - vertical");
                        Console.WriteLine("3 - diagonals");
                        userChooseGame = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        Console.Clear();
                    }

                    while (userChooseGame == PLAY_HORIZONTAL || userChooseGame == PLAY_VERTICAL)
                    {
                        Console.Write("Ho many lines would you like to play?(1 to 3): ");
                        betAmount = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();

                        if (betAmount >= BET_ONE_LINE && betAmount <= slotMachine.GetLength(0))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Selection not avaialable!Try again.");
                        }
                    }
                    while (userChooseGame == PLAY_DIAGONALS)
                    {
                        Console.Write("How many diagonals would you like to play?(1 or 2): ");
                        betAmount = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();

                        if (betAmount >= BET_ONE_LINE && betAmount <= BET_TWO_LINES)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Selection not avaialable!Try again.");
                        }
                    }

                    if (betAmount > totalCreditBalance)
                    {
                        break;
                    }

                    totalCreditBalance -= betAmount;
                    Console.WriteLine($"\t\t\tCredit balance: ${totalCreditBalance}");

                    int rndNum = 0;

                    for (int rowIndex = 0; rowIndex < slotMachine.GetLength(0); rowIndex++)
                    {
                        for (int columnIndex = 0; columnIndex < slotMachine.GetLength(1); columnIndex++)
                        {
                            rndNum = rng.Next(0, 10);
                            slotMachine[rowIndex, columnIndex] = rndNum;
                            Console.Write(rndNum + " ");
                        }
                        Console.WriteLine();
                    }

                    int winningRowCount = 0;

                    if (userChooseGame == PLAY_HORIZONTAL)
                    {
                        Console.WriteLine("\t\t\tPlaying horizontal!");
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

                    if (userChooseGame == PLAY_VERTICAL)
                    {
                        Console.WriteLine("\t\t\tPlaying vertical!");
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

                    if (userChooseGame == PLAY_DIAGONALS)
                    {
                        Console.WriteLine("Playing diagonals!");
                        int matchingNumbers = 0;
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
                                matchingNumbers++;
                            }
                        }
                        if (matchingNumbers >= slotMachine.GetLength(1))
                        {
                            winningRowCount++;
                        }

                        matchingNumbers = 0;
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
                                matchingNumbers++;
                            }
                        }
                        if (matchingNumbers >= slotMachine.GetLength(1))
                        {
                            winningRowCount++;
                        }
                    }
                    Console.WriteLine($"\t\t\tYou've won ${winningRowCount} this round.");
                    credits = totalCreditBalance + winningRowCount;
                }
                Console.WriteLine("Not enough credit available! Press any key to top-up!");
                Console.ReadKey();
            }
        }
    }
}