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
        /// Game mode automatically sets bet amount to "2" as there are only two diagonals to check.
        /// The program will perform a check ar the same time on both diagonals inside the same main FOR loop,
        /// and if at least one element in any diagonals does not match with the next one in the same direction,
        /// the program will ignore that diagonal and continue checking only the diagonal that contains equal elements.
        /// </summary>
        /// <param name="slotMachine">The 2D array to check.</param>
        /// <returns>Returns how many diagonals matched as an integer.</returns>
        public static int CheckDiagonalWin(int[,] slotMachine)
        {
            var winningRowCount = 0;
            
            if (CheckDiagonal(slotMachine, true))
            {
                Console.WriteLine("Left diagonal win!");
                winningRowCount++;
            }
            
            if (CheckDiagonal(slotMachine, false))
            {
                Console.WriteLine("Right diagonal win!");
                winningRowCount++;
            }
            
            return winningRowCount;
        }

        private static bool CheckDiagonal(int[,] slotMachine, bool isCheckingLeft)
        {
            var xAxisIndex = slotMachine.GetLength(0) - 1;
            var adjustmentAmount = -1;
            if (isCheckingLeft)
            {
                xAxisIndex = 0;
                adjustmentAmount = 1;
            }
            
            var diagonalNumbers = new List<int>();
            for (var yAxisIndex = 0; yAxisIndex < slotMachine.GetLength(0); yAxisIndex++)
            {
                diagonalNumbers.Add(slotMachine[xAxisIndex, yAxisIndex]); 
                xAxisIndex += adjustmentAmount;
            }
            
            var toMatch = diagonalNumbers[0];
            return diagonalNumbers.All(x => x.Equals(toMatch));
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