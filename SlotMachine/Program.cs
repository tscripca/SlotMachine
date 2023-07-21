using System;
namespace SlotMachine // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int SLOT_MACHINE_ROWS = 3;
            const int SLOT_MACHINE_COLUMNS = 3;
            const int LUCKY_NUMBER = 7;
            const int MINIMUM_PLAYABLE_AMOUNT = 1;
            bool autoPlay = true;
            int storeLuckyNumbers = 0;
            int creditCash = 0;

            Random rng = new Random();
            int[,] slotMachine = new int[SLOT_MACHINE_ROWS, SLOT_MACHINE_COLUMNS];

            Console.WriteLine("Minimum credit is 1.");
            Console.Write("Insert credit: ");
            creditCash = Convert.ToInt32(Console.ReadLine());

            Console.Clear();

            for (int moneyTracker = creditCash; moneyTracker >= MINIMUM_PLAYABLE_AMOUNT; moneyTracker--)
            {
                while (autoPlay)
                {
                    Console.Clear();
                    storeLuckyNumbers = 0;

                    Console.WriteLine($"\t\t\tBalance {moneyTracker}");

                    for (int rowIndex = 0; rowIndex < slotMachine.GetLength(1); rowIndex++)
                    {
                        for (int columnIndex = 0; columnIndex < slotMachine.GetLength(0); columnIndex++)
                        {
                            int numbersToFill = rng.Next(0, 10);
                            slotMachine[rowIndex, columnIndex] = numbersToFill;
                            Console.Write(numbersToFill + " ");
                            if ((rowIndex == 0 && rowIndex == 2) && columnIndex == 1)
                            {
                                if (numbersToFill == LUCKY_NUMBER)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("CROSS OF SEVENS!!!");
                                }
                            }
                            if (rowIndex == 1)
                            {
                                if (numbersToFill == LUCKY_NUMBER)
                                {
                                    storeLuckyNumbers++;
                                }
                            }
                        }
                        Console.WriteLine();
                    }
                    if (storeLuckyNumbers == 3)
                    {
                        Console.WriteLine("WINNER!");
                        break;
                    }
                }
            }
        }
    }
}