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
            Console.WriteLine("\t\t\t=SLOT MACHINE=");
            Console.WriteLine("GAME RULES:");
            Console.WriteLine($"Insert a deposit and then bet ${1} to ${SLOT_MACHINE_COLUMNS} to start the game.");
            Console.WriteLine("You will automatically place a bet on the number of lines corresponding to the amount inserted.");
            Console.WriteLine("The slot machine will then perform a check both horizonally and vertically on the selected line/s and " +
                              "you will receive $1 for each winning combination.");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue!");
            Console.ReadKey();
            Console.Clear();

            bool autoPlay = true;

            Random rng = new Random();
            int[,] slotMachine = new int[SLOT_MACHINE_ROWS, SLOT_MACHINE_COLUMNS];

            while (autoPlay)
            {
                Console.Write("Insert credit: ");
                int totalCreditBalance = Convert.ToInt32(Console.ReadLine());

                while (totalCreditBalance >= MINIMUM_FEE)
                {
                    Console.Write("How many lines you want to bet?: ");
                    int userChooseLines = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();

                    totalCreditBalance -= userChooseLines;
                    Console.WriteLine($"\t\t\tCredit balance: ${totalCreditBalance}");

                    int numbersToFill = 0;

                    for (int rowIndex = 0; rowIndex < slotMachine.GetLength(0); rowIndex++)
                    {
                        for (int columnIndex = 0; columnIndex < slotMachine.GetLength(1); columnIndex++)
                        {
                            numbersToFill = rng.Next(0, 10);
                            slotMachine[rowIndex, columnIndex] = numbersToFill;
                            Console.Write(numbersToFill + " ");
                        }
                        Console.WriteLine();
                    }

                    for (int rowIndex = 0; rowIndex < slotMachine.GetLength(0); rowIndex++)
                    {
                        for (int columnIndex = 0; columnIndex < slotMachine.GetLength(1); columnIndex++)
                        {

                        }
                    }

                    bool numbersMatch = true;
                    int storeWinningRow = 0;
                    for (int rowIndex = 0; rowIndex < userChooseLines; rowIndex++)
                    {
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
                            Console.WriteLine("Horizontal match!");
                            storeWinningRow++;
                        }
                    }

                    numbersMatch = true;
                    for (int columnIndex = 0; columnIndex < userChooseLines; columnIndex++)
                    {
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
                            Console.WriteLine("Vertical match!");
                            storeWinningRow++;
                        }
                    }

                    totalCreditBalance = totalCreditBalance + storeWinningRow;
                    Console.WriteLine($"\t\t\tYou've won ${storeWinningRow} this round.");
                }
            }
        }
    }
}
