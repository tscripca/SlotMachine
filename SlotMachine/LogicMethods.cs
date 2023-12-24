namespace SlotMachine
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

        /// <summary>
        /// Performs a check when the vertical game mode is selected.
        /// </summary>
        /// <param name="betAmount">Value of the user bet which will determine how many checks the nested for loop should perform.</param>
        /// <param name="slotMachine">The 2D array to check.</param>
        /// <returns>Returns how many lines matched as an integer.</returns>
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

        /// <summary>
        /// Game mode automatically sets bet ampunt to "2" as there are only two diagonals to check.
        /// </summary>
        /// <param name="slotMachine">The 2D array to check.</param>
        /// <returns>Returns how many diagonals matched as an integer.</returns>
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