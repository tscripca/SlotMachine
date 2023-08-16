using System;
namespace SlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int SLOT_MACHINE_ROWS = 3;
            const int SLOT_MACHINE_COLUMNS = 3;
            const int MINIMUM_CREDIT = 1;

            bool autoPlay = true;            

            Random rng = new Random();
            int[,] slotMachine = new int[SLOT_MACHINE_ROWS, SLOT_MACHINE_COLUMNS];

            while (autoPlay)
            {
                Console.Write("Insert credit: ");
                int totalCreditBalance = Convert.ToInt32(Console.ReadLine());

                while (totalCreditBalance >= MINIMUM_CREDIT)
                {
                    Console.WriteLine("1 for horizontal.");
                    Console.WriteLine("2 for vertical");
                    Console.WriteLine("3 for diagonals.");
                    char userChooseLines = Convert.ToChar(Console.ReadLine());

                    Console.WriteLine("$1 to bet one line.");
                    Console.WriteLine("$2 to bet two lines.");
                    Console.WriteLine("$3 to bet all lines.");
                    Console.Write("Insert amount to bet: ");
                    int amountToBet = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();

                    totalCreditBalance = totalCreditBalance - amountToBet;
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

                    int horizontalRowMatch = 0;
                    int verticalRowMatch = 0;
                    int horizontalMatchingNumbers = 0;
                    int verticalMatchingNumbers = 0;
                    int newBalanceAfterWin = totalCreditBalance + amountToBet;
                    int partialWinCredit = 0;

                    while (userChooseLines == '1')
                    {
                        for (int rowIndex = 0; rowIndex < amountToBet; rowIndex++)
                        {
                            horizontalMatchingNumbers = 0;
                            for (int columnIndex = 0; columnIndex < slotMachine.GetLength(1); columnIndex++)
                            {
                                if (slotMachine[rowIndex, 0] == slotMachine[rowIndex, columnIndex])
                                {
                                    horizontalMatchingNumbers++;
                                }
                                if (horizontalMatchingNumbers == slotMachine.GetLength(1))
                                {
                                    horizontalRowMatch++;
                                }
                            }
                        }
                        partialWinCredit = totalCreditBalance + horizontalRowMatch;
                        if (horizontalMatchingNumbers == slotMachine.GetLength(1) * amountToBet)
                        {
                            totalCreditBalance = newBalanceAfterWin;
                            Console.WriteLine("Winning match on selected lines!");
                            Console.WriteLine($"You've won ${amountToBet} back into your account.");
                            Console.WriteLine($"\t\t\tNew credit balance is: ${newBalanceAfterWin}");
                        }
                        else
                        {
                            Console.WriteLine($"No match found on selected lines.");
                        }
                        break;
                    }

                    while (userChooseLines == '2')
                    {
                        for (int rowIndex = 0; rowIndex < slotMachine.GetLength(0); rowIndex++)
                        {
                            for (int columnIndex = 0; columnIndex < amountToBet; columnIndex++)
                            {
                                if (slotMachine[0, rowIndex] == slotMachine[rowIndex, columnIndex])
                                {
                                    verticalMatchingNumbers++;
                                }
                                if(verticalMatchingNumbers == slotMachine.GetLength(0))
                                {
                                    verticalRowMatch++;
                                }
                            }
                        }
                        if (verticalMatchingNumbers == slotMachine.GetLength(1) * amountToBet)
                        {
                            totalCreditBalance = newBalanceAfterWin;
                            Console.WriteLine("Winning match on selected lines!");
                            Console.WriteLine($"You've won ${amountToBet} back into your account.");
                            Console.WriteLine($"\t\t\tNew credit balance is: ${newBalanceAfterWin}");
                        }
                        else
                        {
                            Console.WriteLine($"No match found on selected lines.");
                        }
                        break;
                    }
                    if (horizontalRowMatch == 1)
                    {
                        Console.WriteLine("...but you have one horizontal winning line, somewhere.");
                        Console.WriteLine("$1 goes back into your account.");
                        Console.WriteLine($"\t\t\tNew credit balance is: ${partialWinCredit}");
                    }
                    if (horizontalRowMatch == 2)
                    {
                        Console.WriteLine("...but you have two horizontal winning lines, somewhere.");
                        Console.WriteLine("$2 go back into your account.");
                        Console.WriteLine($"\t\t\tNew credit balance is: ${partialWinCredit}");
                    }
                    if (verticalRowMatch == 1)
                    {
                        Console.WriteLine("...but you have one vertical winning line, somewhere.");
                        Console.WriteLine("$1 goes back into your account.");
                        Console.WriteLine($"\t\t\tNew credit balance is: ${partialWinCredit}");
                    }
                    if (verticalRowMatch == 2)
                    {
                        Console.WriteLine("...but you have two vertical winning lines, somewhere.");
                        Console.WriteLine("$2 go back into your account.");
                        Console.WriteLine($"\t\t\tNew credit balance is: ${partialWinCredit}");
                    }
                }
                Console.WriteLine("Insufficient funds, press any key to top-up!");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}