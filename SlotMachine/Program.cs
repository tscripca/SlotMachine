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
            bool jumpBackToStart = true;
            bool userWantsToPlay = true;
            //UIMethods.DisplayGameRules();
            while (userWantsToPlay)
            {
                //program will come back here when no credit left or not enough to bet. - minimum fee is $1.
                if (jumpBackToStart)
                {
                    Console.Write("Insert credit: $");
                    userCredits = Convert.ToInt32(Console.ReadLine());
                    userCredits += tempStore;
                    UIMethods.ClearScreen();
                    UIMethods.DisplayCreditBalance(userCredits);
                }
                GameMode gameModeEnum = UIMethods.ChooseGameMode();
                int betAmount = UIMethods.SetBetAmount(gameModeEnum);
                userCredits = UIMethods.GetCreditBalance(userCredits, betAmount);
                //the program will stop taking money when there's not enough credit to bet,
                //so negative values are not allowed. 
                if (userCredits < 0)
                {
                    jumpBackToStart = true;
                    //because SetBetAmount() could output a negative value,
                    //tempStore will store the userCredit before placing the bet, this way the user can then
                    //top-up with credit on top of a positive value.
                    tempStore = betAmount + userCredits;
                    UIMethods.ShowInsufficientFundsMessage();
                    continue;
                }
                else
                {
                    jumpBackToStart = false;
                }
                UIMethods.DisplayCreditBalance(userCredits);
                //generate slot machine values
                slotMachine = LogicMethods.GenerateSlotMachineValues();
                UIMethods.PrintSlotMachineValues(slotMachine);                
                int winningRowCount = 0;
                if (gameModeEnum == GameMode.horizontal)
                {
                    winningRowCount = LogicMethods.CheckHorizontalWin(betAmount, slotMachine);
                }
                if (gameModeEnum == GameMode.vertical)
                {
                    winningRowCount = LogicMethods.CheckVerticalWin(betAmount, slotMachine);
                }
                if (gameModeEnum == GameMode.diagonal)
                {
                    winningRowCount = LogicMethods.CheckDiagonalWin(slotMachine);
                }
                UIMethods.DisplayWinValue(winningRowCount);
                userCredits = UIMethods.GetEarnedCredits(userCredits, winningRowCount);
                //wait to reach zero credit then ask if the user wants to continue or stop playing.
                if (userCredits == 0)
                {
                    if (UIMethods.GetUserDecision() == true)
                    {
                        //userWantsToPlay = true;
                        jumpBackToStart = true;
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