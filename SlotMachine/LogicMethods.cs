using slotMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    public static class LogicMethods
    {
        public static int CheckBetAmount(int betAmount)
        {
            while (true)
            {
                if (betAmount >= Program.lowerBetBound && betAmount <= Program.upperBetBound)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Selection not avaialable!Try again.");
                    break;
                }
            }
            return betAmount;
        }        
    }
}
