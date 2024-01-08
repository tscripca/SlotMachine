using System.Net.Security;

namespace SlotMachine
{
    public static class Program
    {
        public static readonly Random rng = new Random();
        static void Main(string[] args)
        {
            int[,] slotMachine = new int[Constants.SLOT_MACHINE_ROWS, Constants.SLOT_MACHINE_COLUMNS];
            int userCredits = 0;
            int tempStore = 0;
            int linesToPlay = 0;
            bool userWantsToPlay = true;
            //UIMethods.DisplayGameRules();
            while (userWantsToPlay)
            {
                userCredits = UIMethods.SetCreditValue(userCredits, tempStore);
                GameMode gameModeEnum = UIMethods.ChooseGameMode();
                linesToPlay = UIMethods.SetBetAmount(gameModeEnum);
                userCredits = UIMethods.GetCreditBalance(userCredits, linesToPlay);
                if (userCredits < 0)
                {                    
                    tempStore = linesToPlay + userCredits;
                    UIMethods.ShowInsufficientFundsMessage();
                    continue;
                }
                UIMethods.DisplayCreditBalance(userCredits);
                slotMachine = LogicMethods.GenerateSlotMachineValues();
                UIMethods.PrintSlotMachineValues(slotMachine);
                int winningRowCount = 0;
                if (gameModeEnum == GameMode.horizontal)
                {
                    winningRowCount = LogicMethods.CheckHorizontalWin(linesToPlay, slotMachine);
                }
                if (gameModeEnum == GameMode.vertical)
                {
                    winningRowCount = LogicMethods.CheckVerticalWin(linesToPlay, slotMachine);
                }
                if (gameModeEnum == GameMode.diagonal)
                {
                    winningRowCount = LogicMethods.CheckDiagonalWin(slotMachine);
                }
                UIMethods.DisplayWinValue(winningRowCount);
                userCredits = UIMethods.GetEarnedCredits(userCredits, winningRowCount);
                if (userCredits == 0)
                {
                    if (UIMethods.GetUserDecision() == true)
                    
                    
                    {
                        userWantsToPlay = true;
                    }
                    else
                    {
                        userWantsToPlay = false;
                    }
                }
            }
        }
    }
}