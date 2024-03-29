﻿namespace SlotMachine
{
    public static class LogicMethods
    {
        /// <summary>
        /// Performs a check when the horizontal game mode is selected.
        /// </summary>
        /// <param name="betAmount">Value of the user bet which will determine how many checks the nested for loop should perform.</param>
        /// <param name="slotMachine">The 2D array to check.</param>
        /// <returns>Returns how many lines matched as an integer.</returns>
        public static int CheckHorizontalWin(int betAmount, int[,] slotMachine)
        {
            int winningHorizontal = 0;
            int rowIndex = 0;
            bool numbersMatch = true;
            while (rowIndex < betAmount)
            {
                for (int columnIndex = 0; columnIndex < betAmount; columnIndex++)
                {
                    if (slotMachine[0, 0] != slotMachine[rowIndex, columnIndex])
                    {
                        numbersMatch = false; 
                        break;
                    }
                }
                if (numbersMatch)
                {
                    winningHorizontal++;
                }
                rowIndex++;
            }
            return winningHorizontal;
        }

        /// <summary>
        /// Performs a check when the vertical game mode is selected.
        /// </summary>
        /// <param name="betAmount">Value of the user bet which will determine how many checks the nested for loop should perform.</param>
        /// <param name="slotMachine">The 2D array to check.</param>
        /// <returns>Returns how many lines matched as an integer.</returns>
        public static int CheckVerticalWin(int betAmount, int[,] slotMachine)
        {
            int winningVertical = 0;
            int columnIndex = 0;
            bool numbersMatch = true;
            while (columnIndex < betAmount )
            {
                for (int rowIndex = 0; rowIndex < betAmount; rowIndex++)
                {
                    if (slotMachine[0, columnIndex] != slotMachine[rowIndex, columnIndex])
                    {
                        numbersMatch = false;
                        break;
                    }
                }
                if (numbersMatch)
                {
                    winningVertical++;
                }
                columnIndex++;
            }
            return winningVertical++;
        }

        /// <summary>
        /// Game mode automatically sets bet amount to "2" as there are only two diagonals to check.
        /// The program will perform a check ar the same time on both diagonals inside the same main FOR loop,
        /// and if at least one element in any diagonals does not match with the next one in the same direction,
        /// the program will ignore that diagonal and continue checking only the diagonal that contains equal elements.
        /// </summary>
        /// <param name="slotMachine">The 2D array to check.</param>
        /// <returns>Returns how many diagonals matched as an integer.</returns>
        public static int CheckDiagonalWin(int[,] slotMachine)
        {
            int lastColumnIndex = Constants.SLOT_MACHINE_COLUMNS - Constants.BET_ONE_LINE;
            int variableColumnIndex = Constants.SLOT_MACHINE_COLUMNS - Constants.BET_ONE_LINE;
            bool leftDiagonalMatch = true;
            bool rightDiagonalMatch = true;
            int winningDiagonal = 0;
            for (int rowIndex = 0; rowIndex < slotMachine.GetLength(0); rowIndex++, variableColumnIndex--)
            {
                int columnIndex = rowIndex;
                if (slotMachine[0, 0] != slotMachine[rowIndex, columnIndex])
                {
                    leftDiagonalMatch = false;
                }
                if (slotMachine[0, lastColumnIndex] != slotMachine[rowIndex, variableColumnIndex])
                {
                    rightDiagonalMatch = false;
                }
            }
            if (leftDiagonalMatch)
                winningDiagonal++;
            if (rightDiagonalMatch)
                winningDiagonal++;
            return winningDiagonal;
        }

        /// <summary>
        /// This method will fill the array with random values.
        /// </summary>
        /// <returns>Returns the int[,] value of the 2D array</returns>
        public static int[,] GenerateSlotMachineValues()
        {
            int[,] twoDimensionArray = new int[Constants.SLOT_MACHINE_ROWS, Constants.SLOT_MACHINE_COLUMNS];
            for (int rowIndex = 0; rowIndex < Constants.SLOT_MACHINE_ROWS; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < Constants.SLOT_MACHINE_COLUMNS; columnIndex++)
                {
                    int randomValue = Program.rng.Next(0, Constants.UPPPER_BOUND);
                    twoDimensionArray[rowIndex, columnIndex] = randomValue;
                }
            }
            return twoDimensionArray;
        }
    }
}