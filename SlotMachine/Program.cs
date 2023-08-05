using System;
namespace SlotMachine // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int SLOT_MACHINE_ROWS = 3;
            const int SLOT_MACHINE_COLUMNS = 3;
            bool autoPlay = true;
            int numbersToFill = 0;
            int numberOfTimesPlayed = 0; 
            int remainingCredit = 0;
            int rowIndex = 0;
            int columnIndex = 0;
            int countWinningLines = 0;
            Random rng = new Random();
            int[,] slotMachine = new int[SLOT_MACHINE_ROWS, SLOT_MACHINE_COLUMNS]; 
            //slotMachine[0, 0] = 3; slotMachine[0, 1] = 3; slotMachine[0, 2] = 3;
            //slotMachine[1, 0] = 5; slotMachine[1, 1] = 5; slotMachine[1, 2] = 5;
            //slotMachine[2, 0] = 6; slotMachine[2, 1] = 6; slotMachine[2, 2] = 6;
            while (autoPlay)
            {
                Console.Write("Insert credit: ");
                int userCreditBalance = Convert.ToInt32(Console.ReadLine());
                for (numberOfTimesPlayed = 1; numberOfTimesPlayed <= userCreditBalance; numberOfTimesPlayed++)
                {
                    Console.WriteLine();
                    Console.WriteLine("Press 1 to bet on the top line.");
                    Console.WriteLine("Press 2 to bet on the middle line.");
                    Console.WriteLine("Press 3 to bet on the bottom line.");
                    Console.WriteLine("Press 4 to bet on all three lines.");
                    Console.Write("Choose line to bet: ");
                    int userChooseLine = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    int countOfAllIndexes = 0;//each round the count of indexes resets back to 0.                
                    for (rowIndex = 0; rowIndex < slotMachine.GetLength(0); rowIndex++)
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
                    //for (int i = 0; i < slotMachine.GetLength(0); i++)
                    //{
                    //    for (int j = 0; j < slotMachine.GetLength(1); j++)
                    //    {
                    //        Console.Write(slotMachine[i, j] + " ");
                    //        countOfAllIndexes++;
                    //    }
                    //    Console.WriteLine();
                    //}
                    int recordTopRowMatches = 0; //ressets all counters back to 0 after each bet/round.
                    int recordMiddleRowMatches = 0;
                    int recordBottomRowMatches = 0;
                    remainingCredit = userCreditBalance - numberOfTimesPlayed;
                    Console.WriteLine($"\t\tCredit balance: {remainingCredit}");
                    for (rowIndex = 0; rowIndex < slotMachine.GetLength(0); rowIndex++)
                    {
                        for (columnIndex = 0; columnIndex < slotMachine.GetLength(1); columnIndex++)
                        {
                            if (slotMachine[rowIndex, 0] == slotMachine[rowIndex, columnIndex])
                            {
                                switch (rowIndex)
                                {
                                    case 0:
                                        recordTopRowMatches++;//if equal to 3 then winning line.
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
                                remainingCredit++;
                                Console.WriteLine("Top line winning.");
                            }
                            else
                            {
                                Console.WriteLine("No winning cobination on top line.");
                            }
                            break;
                        case 2:
                            if (recordMiddleRowMatches >= SLOT_MACHINE_COLUMNS)
                            {
                                remainingCredit++;
                                Console.WriteLine("Middle line winning.");
                            }
                            else
                            {
                                Console.WriteLine("No winning combination on middle line.");
                            }
                            break;
                        case 3:
                            if (recordBottomRowMatches >= SLOT_MACHINE_COLUMNS)
                            {
                                remainingCredit++;
                                Console.WriteLine("Bottom line winning.");
                            }
                            else
                            {
                                Console.WriteLine("No winning combination on bottom line.");
                            }
                            break;
                        case 4:
                            if (countWinningLines >= countOfAllIndexes)
                            {
                                remainingCredit += 3;
                                Console.WriteLine("All winning lines.");
                            }
                            else
                            {
                                Console.WriteLine("No winning combination on all three lines.");
                            }
                            break;
                    }
                    countWinningLines = 0;//resets the counter after the selected row has been checked.
                }
                Console.WriteLine("No credit available, press any key to top-up.");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}