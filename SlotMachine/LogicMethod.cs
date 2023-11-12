using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    public static class LogicMethod
    {
        public static GameMode ValidateGameMode()
        {
            switch (gameModEnum)
            {
                case GameMode.horizontal:
                    Console.WriteLine("How many lines would you like to play?: ");
                    betAmount = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    break;
                case GameMode.vertical:
                    Console.WriteLine("How many lines would you like to play?: ");
                    betAmount = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    break;
                case GameMode.diagonal:
                    betAmount = Constants.BET_TWO_DOLLARS;
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
            return betAmount;
        }
    }
}
