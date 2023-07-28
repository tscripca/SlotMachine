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

            int firstRow = 0;
            int firstRowPositionZero = 0;
            int firstRowPositionOne = 0;
            int firstRowPositionTwo = 0;
            int secondRow = 1;
            int secondRowPositionZero = 0;
            int secondRowPositionOne = 0;
            int secondRowPositionTwo = 0;
            int thirdRow = 2;
            int thirdRowPositionZero = 0;
            int thirdRowPositionOne = 0;
            int thirdRowPositionTwo = 0;

            int topRowMatchRecord = 0;
            int middleRowMatchRecord = 0;
            int bottomRowMatchRecord = 0;

            Random rng = new Random();
            int[,] slotMachine = new int[SLOT_MACHINE_ROWS, SLOT_MACHINE_COLUMNS];

            while (autoPlay)
            {
                Console.Clear();

                for (int rowIndex = 0; rowIndex < slotMachine.GetLength(1); rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < slotMachine.GetLength(0); columnIndex++)
                    {
                        numbersToFill = rng.Next(0, 10);
                        slotMachine[rowIndex, columnIndex] = numbersToFill;
                        Console.Write(numbersToFill + " ");
                    }
                    Console.WriteLine();
                }

                for (int loopFirstRow = 0; loopFirstRow < slotMachine.GetLength(0); loopFirstRow++)
                {
                    switch (loopFirstRow)
                    {
                        case 0:
                            firstRowPositionZero = slotMachine[firstRow, loopFirstRow];
                            break;

                        case 1:
                            firstRowPositionOne = slotMachine[firstRow, loopFirstRow];
                            break;

                        case 2:
                            firstRowPositionTwo = slotMachine[firstRow, loopFirstRow];
                            break;
                    }
                }

                for (int loopSecondRow = 0; loopSecondRow < slotMachine.GetLength(0); loopSecondRow++)
                {
                    switch (loopSecondRow)
                    {
                        case 0:
                            secondRowPositionZero = slotMachine[secondRow, loopSecondRow];
                            break;

                        case 1:
                            secondRowPositionOne = slotMachine[secondRow, loopSecondRow];
                            break;

                        case 2:
                            secondRowPositionTwo = slotMachine[secondRow, loopSecondRow];
                            break;
                    }
                }

                for (int loopThirdRow = 0; loopThirdRow < slotMachine.GetLength(0); loopThirdRow++)
                {
                    switch (loopThirdRow)
                    {
                        case 0:
                            thirdRowPositionZero = slotMachine[thirdRow, loopThirdRow];
                            break;

                        case 1:
                            thirdRowPositionOne = slotMachine[thirdRow, loopThirdRow];
                            break;

                        case 2:
                            thirdRowPositionTwo = slotMachine[thirdRow, loopThirdRow];
                            break;
                    }
                }

                Console.WriteLine();

                //check for winning combinations
                if (firstRowPositionZero == firstRowPositionOne && firstRowPositionOne == firstRowPositionTwo)
                {
                    topRowMatchRecord++;
                }

                if (secondRowPositionZero == secondRowPositionOne && secondRowPositionOne == secondRowPositionTwo)
                {
                    middleRowMatchRecord++;
                }

                if (thirdRowPositionZero == thirdRowPositionOne && thirdRowPositionOne == thirdRowPositionTwo)
                {
                    bottomRowMatchRecord++;
                }

                //check which rows are winning
                if (middleRowMatchRecord == 1)
                {
                    Console.WriteLine("You've matched the top row.");
                    break;
                }

                if (middleRowMatchRecord == 1)
                {
                    Console.WriteLine("You've matched the middle row.");
                    break;
                }

                if (bottomRowMatchRecord == 1)
                {
                    Console.WriteLine("You've matched the bottom row.");
                    break;
                }
            }
        }
    }
}