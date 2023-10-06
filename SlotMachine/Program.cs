using System;
namespace SlotMachine
{
    enum GameMode
    {
        horizontal,
        vertical,
        diagonal
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            const int SLOT_MACHINE_ROWS = 3;
            const int SLOT_MACHINE_COLUMNS = 3;
            const int UPPPER_BOUND = 10;
            const int BET_ONE_LINE = 1;
            const int BET_TWO_LINES = 2;
            const int MINIMUM_FEE = 1;
            Random rng = new Random();
            int[,] slotMachine = new int[SLOT_MACHINE_ROWS, SLOT_MACHINE_COLUMNS];
            int lastColumnIndex = slotMachine.GetLength(1) - 1;
            //Console.WriteLine("\t\t\t=SLOT MACHINE=");
            //Console.WriteLine($"This is a {SLOT_MACHINE_ROWS} by {SLOT_MACHINE_COLUMNS} slot machine.");
            //Console.WriteLine("Insert credit amount then choose between three game types, Horizontal, Vertical or Diagonal.");
            //Console.WriteLine($"Each round you can bet on {BET_ONE_LINE}, {BET_TWO_LINES} up to {SLOT_MACHINE_ROWS} lines.");
            //Console.WriteLine("Credit will be deducted from your balance proportionally with the number of lines you're playing, and " +
            //    $"will be added back into your account in case of a win for each matching line.(bet {BET_TWO_LINES} lines and match then ${BET_TWO_LINES} will be added to your account.)");
            //Console.WriteLine("Press any key to start!");
            //Console.ReadKey();
            //Console.Clear();
            int userCredits = 0;
            int creditsRemaining = 0;
            int betAmount = 0;
            bool autoPlay = true;
            string userGameMode = "";            
            while (autoPlay)
            {
                while (userCredits < MINIMUM_FEE)
                {
                    Console.Write("Insert credit: ");
                    userCredits = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                }
                userCredits += creditsRemaining;
                Console.Clear();
                GameMode gameModEnum = GameMode.horizontal;
                Console.WriteLine($"\t\t\tCredit balance: ${userCredits}");
                bool checkValue = false;
                while (!checkValue)
                {
                    Console.WriteLine("Choose game mode:");
                    Console.WriteLine("h - horizontal");
                    Console.WriteLine("v - vertical");
                    Console.WriteLine("d - diagonals");
                    userGameMode = Console.ReadLine();
                    if (userGameMode == "h" || userGameMode == "v" || userGameMode == "d")
                    {
                        checkValue = true;
                    }
                }
                switch (userGameMode)
                {
                    case "h": gameModEnum = GameMode.horizontal; break;
                    case "v": gameModEnum = GameMode.vertical; break;
                    case "d": gameModEnum = GameMode.diagonal; break;
                    default: Console.WriteLine("Not valid!"); break;
                }
                switch (gameModEnum)
                {
                    case GameMode.horizontal:
                        while (true)
                        {
                            Console.Write($"Ho many lines would you like to play?({BET_ONE_LINE} to {SLOT_MACHINE_ROWS}): ");
                            betAmount = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();
                            if (betAmount >= BET_ONE_LINE && betAmount <= slotMachine.GetLength(0))
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Selection not avaialable!Try again.");
                            }
                        }
                        break;
                    case GameMode.vertical:
                        while (true)
                        {
                            Console.Write($"Ho many lines would you like to play?({BET_ONE_LINE} to {SLOT_MACHINE_ROWS}): ");
                            betAmount = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();
                            if (betAmount >= BET_ONE_LINE && betAmount <= slotMachine.GetLength(0))
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Selection not avaialable!Try again.");
                            }
                        }
                        break;
                    case GameMode.diagonal:
                        betAmount = BET_TWO_LINES;
                        while (true)
                        {
                            break;
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
                if (creditsRemaining < MINIMUM_FEE)
                {
                    autoPlay = true;
                    break;
                }
                creditsRemaining = userCredits - betAmount;
                Console.WriteLine($"\t\t\tCredit balance: ${creditsRemaining}");
                int rndNum = 0;
                for (int rowIndex = 0; rowIndex < slotMachine.GetLength(0); rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < slotMachine.GetLength(1); columnIndex++)
                    {
                        rndNum = rng.Next(0, UPPPER_BOUND);
                        slotMachine[rowIndex, columnIndex] = rndNum;
                        Console.Write(rndNum + " ");
                    }
                    Console.WriteLine();
                }
                int winningRowCount = 0;
                if (gameModEnum == GameMode.horizontal)
                {
                    Console.WriteLine("\t\t\tPlaying horizontal!");
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
                }
                if (gameModEnum == GameMode.vertical)
                {
                    Console.WriteLine("\t\t\tPlaying vertical!");
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
                }
                if (gameModEnum == GameMode.diagonal)
                {
                    Console.WriteLine("\t\t\tPlaying diagonals!");
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
                }                
                Console.WriteLine($"\t\t\tYou've won ${winningRowCount} this round.");
                userCredits = creditsRemaining + winningRowCount;
            }
        }
    }
}