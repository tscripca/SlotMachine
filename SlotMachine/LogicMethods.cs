using SlotMachine;
using System;

namespace SlotMachine
{
    public static class LogicMethods
    {
        public static int CheckHorizontalWin(int betAmount, int[,] slotMachine)
        {
            int winningRowCount = 0;
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
            return winningRowCount;
        }
        public static int CheckVerticalWin(int betAmount, int[,] slotMachine)
        {
            int winningRowCount = 0;
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
            return winningRowCount++;
        }
        public static int CheckDiagonalWin(int[,] slotMachine)
        {
            int lastColumnIndex = Constants.SLOT_MACHINE_COLUMNS - 1;
            int winningRowCount = 0;
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
            return winningRowCount++;
        }                        
        //public static int GridGenerator()
        //{
        //    int[,] slotMachine = new int[Constants.SLOT_MACHINE_ROWS, Constants.SLOT_MACHINE_COLUMNS];
        //    Random rng = new Random();
        //    int rndNum = 0;
        //    for (int rowIndex = 0; rowIndex < Constants.SLOT_MACHINE_ROWS; rowIndex++)
        //    {
        //        for (int columnIndex = 0; columnIndex < Constants.SLOT_MACHINE_COLUMNS; columnIndex++)
        //        {
        //            rndNum = rng.Next(0, Constants.UPPPER_BOUND);
        //            slotMachine[rowIndex, columnIndex] = rndNum;
        //            Console.Write(rndNum + " ");
        //        }
        //        UIMethods.AddEmptyLine();
        //    }
        //    return rndNum;
        //}
    }
}