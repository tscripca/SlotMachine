using System;
namespace SlotMachine // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int SLOT_MACHINE_ROWS = 3;
            const int SLOT_MACHINE_COLUMNS = 3;
            const int ONE_DOLLAR_BET = 1;
            const int THREE_DOLLARS_BET = 3;
            const int ONE_DOLLAR_WIN = 1;
            const int THREE_DOLLARS_WIN = 3;

            bool autoPlay = true; 

            int columnIndex = 0;
            int countWinningLines = 0;

            Random rng = new Random();
            int[,] slotMachine = new int[SLOT_MACHINE_ROWS, SLOT_MACHINE_COLUMNS];

            while (autoPlay)
            {
                Console.Write("Insert credit: ");
                int userCreditBalance = Convert.ToInt32(Console.ReadLine());                

                while (userCreditBalance > 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Press 1 bet top line.");
                    Console.WriteLine("Press 2 bet middle line.");
                    Console.WriteLine("Press 3 bet bottom line.");
                    Console.WriteLine("Press 4 to bet all lines.");

                    Console.Write("Choose line to bet: ");
                    int userChooseLine = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();

                    if (userCreditBalance < THREE_DOLLARS_BET)
                    {
                        Console.WriteLine("\t\tInsufficient funds, please top-up!");
                        break;
                    }

                    int countOfAllIndexes = 0;//each round the count of indexes resets back to 0.
                    int numbersToFill = 0;

                    for (int rowIndex = 0; rowIndex < slotMachine.GetLength(0); rowIndex++)
                    {
                        for (columnIndex = 0; columnIndex < slotMachine.GetLength(1); columnIndex++)
                        {
                            numbersToFill = rng.Next(0, 10);
                            slotMachine[rowIndex, columnIndex] = numbersToFill;
                            Console.Write(numbersToFill + " ");
                            countOfAllIndexes++;//the total number of elements in the array.
                        }
                        Console.WriteLine();
                    }

                    switch (userChooseLine)
                    {
                        case 1:
                            userCreditBalance -= ONE_DOLLAR_BET;
                            Console.WriteLine("\t\t1$ has been deducted from your balance.");
                            break;
                        case 2:
                            userCreditBalance -= ONE_DOLLAR_BET;
                            Console.WriteLine("\t\t1$ has been deducted from your balance.");
                            break;
                        case 3:
                            userCreditBalance -= ONE_DOLLAR_BET;
                            Console.WriteLine("\t\t1$ has been deducted from your balance.");
                            break;
                        case 4:                            
                            userCreditBalance -= THREE_DOLLARS_BET;
                            Console.WriteLine("\t\t3$ have been deducted from your balance.");
                            break;
                    }

                    int recordTopRowMatches = 0; //ressets all counters back to 0 after each bet/round.
                    int recordMiddleRowMatches = 0;
                    int recordBottomRowMatches = 0;

                    for (int rowIndex = 0; rowIndex < slotMachine.GetLength(0); rowIndex++)
                    {
                        for (columnIndex = 0; columnIndex < slotMachine.GetLength(1); columnIndex++)
                        {
                            if (slotMachine[rowIndex, 0] == slotMachine[rowIndex, columnIndex])
                            {
                                switch (rowIndex)
                                {
                                    case 0:
                                        recordTopRowMatches++;//if equal to 3 then it's a winning line.
                                        countWinningLines++;//if equal to the total number of all indexes in the array, then all winning lines.
                                        break;
                                    case 1:
                                        recordMiddleRowMatches++;
                                        countWinningLines++;
                                        break;
                                    case 2:
                                        recordBottomRowMatches++;
                                        countWinningLines++;
                                        break;
                                }
                            }
                        }
                    }

                    switch (userChooseLine)
                    {
                        case 1:
                            if (recordTopRowMatches >= SLOT_MACHINE_COLUMNS)
                            {
                                userCreditBalance += 1;
                                Console.WriteLine("\t\tTop line winning.");
                            }
                            else
                            {
                                Console.WriteLine("\t\tNo winning cobination on top line.");
                            }
                            break;
                        case 2:
                            if (recordMiddleRowMatches >= SLOT_MACHINE_COLUMNS)
                            {
                                userCreditBalance += ONE_DOLLAR_WIN;
                                Console.WriteLine("\t\tMiddle line winning.");
                            }
                            else
                            {
                                Console.WriteLine("\t\tNo winning combination on middle line.");
                            }
                            break;
                        case 3:
                            if (recordBottomRowMatches >= SLOT_MACHINE_COLUMNS)
                            {
                                userCreditBalance += ONE_DOLLAR_WIN;
                                Console.WriteLine("\t\tBottom line winning.");
                            }
                            else
                            {
                                Console.WriteLine("\t\tNo winning combination on bottom line.");
                            }
                            break;
                        case 4:
                            if (countWinningLines >= countOfAllIndexes)
                            {
                                userCreditBalance += THREE_DOLLARS_WIN;
                                Console.WriteLine("\t\tAll winning lines.");
                            }
                            else
                            {
                                Console.WriteLine("\t\tNo winning combination on the three lines.");

                                if (recordTopRowMatches >= 3)
                                {
                                    userCreditBalance += ONE_DOLLAR_WIN;
                                    Console.WriteLine("\t\t...but you still get 1$ for the top line win!");
                                }
                                else if (recordMiddleRowMatches >= 3)
                                {
                                    userCreditBalance += ONE_DOLLAR_WIN;
                                    Console.WriteLine("\t\t..but you still get 1$ for the middle line win!");
                                }
                                else if (recordBottomRowMatches >= 3)
                                {
                                    userCreditBalance += ONE_DOLLAR_WIN;
                                    Console.WriteLine("\t\t...but you still get 1$ for the bottom line win!");
                                }
                            }
                            break;
                    }
                    Console.WriteLine();
                    Console.WriteLine($"\t\t\tCredit balance: {userCreditBalance}");
                    countWinningLines = 0;//resets the counter after the selected row has been checked.
                }

                Console.WriteLine("No credit available, press any key to top-up.");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}