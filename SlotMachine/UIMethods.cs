using System.Reflection.PortableExecutable;

namespace SlotMachine
{
    public static class UIMethods
    {
        public static void ClearScreen()
        {
            Console.Clear();
        }
        public static void AddEmptyLine()
        {
            Console.WriteLine();
        }
        public static void GetKey()
        {
            Console.ReadKey();
        }
        /// <summary>
        /// Informs the user when there are not enough credits to bet.
        /// </summary>
        public static void ShowInsufficientFundsMessage()
        {
            Console.WriteLine("Not enough credit to play!");
        }
        /// <summary>
        /// Permanently displays the remaining credit.
        /// </summary>
        /// <param name="creditValue"></param>
        /// <returns>Returns an int value.</returns>
        public static int DisplayCreditBalance(int creditValue)
        {
            Console.WriteLine($"\t\t\t\tCredit balance: {creditValue}");
            return creditValue;
        }
        /// <summary>
        /// Displays how much user has won after each round.
        /// </summary>
        /// <param name="linesMatch">The value to be printed on screen.</param>
        /// <returns>Returns an int value.</returns>
        public static int DisplayWinValue(int linesMatch)
        {
            Console.WriteLine($"You've won ${linesMatch} this round.");
            return linesMatch;
        }
        /// <summary>
        /// Calculates the remaining credit after each bet.
        /// </summary>
        /// <param name="userMoney">User initial credit.</param>
        /// <param name="linesToBet">Amount they bet each round.</param>
        /// <returns>Returns an integer value.</returns>
        public static int GetCreditBalance(int userMoney, int linesToBet)
        {
            int creditToDisplay = userMoney - linesToBet;
            return creditToDisplay;
        }
        /// <summary>
        /// Calculate how much user has won after each round and adds up to user's credit balance.
        /// </summary>
        /// <param name="moneyLeft">User money after each bet.</param>
        /// <param name="linesMatch">How many lines he won/matched.</param>
        /// <returns>Returns an integer value.</returns>
        public static int GetEarnedCredits(int moneyLeft, int linesMatch)
        {
            int totalWin = moneyLeft + linesMatch;
            return totalWin;
        }
        /// <summary>
        /// Displays the game rules on screen.
        /// </summary>
        public static void DisplayGameRules()
        {
            Console.WriteLine("\t\t\t=SLOT MACHINE=");
            Console.WriteLine($"This is a {Constants.SLOT_MACHINE_ROWS} by {Constants.SLOT_MACHINE_COLUMNS} slot machine game.");
            Console.WriteLine("Insert credit then choose between three game types, Horizontal(H), Vertical(V) or Diagonal(D).");
            Console.WriteLine($"Each round you will be asked to bet either {Constants.BET_ONE_DOLLAR}, {Constants.BET_TWO_DOLLARS} up to {Constants.SLOT_MACHINE_ROWS} lines.");
            Console.WriteLine("Credit will be deducted from your balance proportionally with the number of lines you're playing, and " +
                $"will be added back into your account, in case of a win, for each winning line (e.g.match {Constants.BET_TWO_DOLLARS} lines, win ${Constants.BET_TWO_DOLLARS})");
            Console.WriteLine("Press any key to start!");
            GetKey();
            ClearScreen();
        }
        /// <summary>
        /// User input validation.
        /// Grants user the choice to play one of the three game modes available.
        /// </summary>
        /// <returns>Returns an enum.</returns>
        public static GameMode ChooseGameMode()
        {
            GameMode gameModeEnum = GameMode.invalid;
            while (gameModeEnum == GameMode.invalid)
            {
                Console.WriteLine("Choose game mode: (h, v, d)");
                ConsoleKeyInfo userAnswer = Console.ReadKey();
                char userGameMode = userAnswer.KeyChar;
                ClearScreen();
                AddEmptyLine();
                switch (userGameMode)
                {
                    case 'h': gameModeEnum = GameMode.horizontal; break;
                    case 'v': gameModeEnum = GameMode.vertical; break;
                    case 'd': gameModeEnum = GameMode.diagonal; break;
                    default:
                        gameModeEnum = GameMode.invalid;
                        Console.WriteLine("Selection not available!"); break;
                }
            }
            return (GameMode)gameModeEnum;
        }
        /// <summary>
        /// User input validation.
        /// After game mode is selected, the user can now select how many rows to play, which represents the amount of money to bet.
        /// </summary>
        /// <param name="chosenMode"></param>
        /// <returns>Returns an int value.</returns>
        public static int SetBetAmount(GameMode chosenMode)
        {
            int betAmount = 0;
            bool betAmountPass = false;
            switch (chosenMode)
            {
                case GameMode.horizontal:
                case GameMode.vertical:
                    while (!betAmountPass)
                    {
                        Console.WriteLine($"How many lines would you like to play?: ({Constants.BET_ONE_DOLLAR} to {Constants.SLOT_MACHINE_ROWS})");
                        ConsoleKeyInfo getAnswer = Console.ReadKey();
                        betAmount = int.Parse(getAnswer.KeyChar.ToString());
                        ClearScreen();
                        if (betAmount >= Constants.BET_ONE_DOLLAR && betAmount <= Constants.SLOT_MACHINE_ROWS)
                        {
                            betAmountPass = true;
                        }
                        else
                        {
                            betAmountPass = false;
                            Console.WriteLine("Selection not available");
                        }
                    }
                    break;
                case GameMode.diagonal:
                    betAmount = Constants.BET_TWO_DOLLARS;
                    break;
            }
            return betAmount;
        }
        /// <summary>
        /// In some cases it may ask the user if he wants to continue playing.
        /// </summary>
        /// <returns>Returns a boolean value.</returns>
        public static bool GetUserDecision()
        {
            bool userDecision;
            ShowInsufficientFundsMessage();
            Console.WriteLine("Keep playing? Y/N: ");
            ConsoleKeyInfo userAnswer = Console.ReadKey();
            char keepPlaying = (char)userAnswer.KeyChar;
            AddEmptyLine();
            if (keepPlaying == 'y')
            {
               userDecision = true;
            }
            else
            {
                userDecision = false;
            }
            return userDecision;
        }
        /// <summary>
        /// Prints the 2D Array's random values to the screen.
        /// </summary>
        /// <param name="gridArray">Takes in the value from the LogicMethod.</param>
        /// <returns>Returns an int[,] value.</returns>
        public static int [,] PrintSlotMachineValues(int[,] gridArray)
        {
            for (int rowIndex = 0; rowIndex < Constants.SLOT_MACHINE_ROWS; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < Constants.SLOT_MACHINE_COLUMNS; columnIndex++)
                {
                    int randomValue = gridArray[rowIndex, columnIndex];
                    Console.Write(randomValue + " ");
                }
                UIMethods.AddEmptyLine();
            }
            return gridArray;
        }
    }
}