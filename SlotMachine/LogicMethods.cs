using SlotMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}