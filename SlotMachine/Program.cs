using System;

namespace SlotMachine // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int SLOT_MACHINE_ROWS = 3;
            const int SLOT_MACHINE_COLUMNS = 3;
            int numbersToFill = 0;
            bool autoPlay = true;

            int rowIndex = 0;
            int columnIndex = 0;

            Random rng = new Random();
            int[,] slotMachine = new int[SLOT_MACHINE_ROWS, SLOT_MACHINE_COLUMNS];

            while (autoPlay)
            {
                Console.Clear();

                for (rowIndex = 0; rowIndex < slotMachine.GetLength(1); rowIndex++)
                {
                    for (columnIndex = 0; columnIndex < slotMachine.GetLength(0); columnIndex++)
                    {
                        numbersToFill = rng.Next(0, 10);
                        slotMachine[rowIndex, columnIndex] = numbersToFill;
                        Console.Write(numbersToFill + " ");
                    }
                    Console.WriteLine();
                }

                int rowToCheck = 0;

                for (int rowLoop = 0; rowLoop < SLOT_MACHINE_COLUMNS; rowLoop++) 
                {
                    Console.Write(slotMachine[rowToCheck, rowLoop]  + " ");
                }
                break;
            }
        }
    }
}