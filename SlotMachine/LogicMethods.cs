using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    internal class LogicMethods
    {
        static int HowManyLines(int userChooseLines)
        {
            Console.WriteLine("How many lines would you like to play?: ");
            int lines = Convert.ToInt32(Console.ReadLine());
            return lines;
        }
        static int CheckBetAmount(int x, int y)
        {
            int betAmount = Convert.ToInt32(Console.ReadLine());
            while (true)
            {
                if (betAmount >= x && betAmount <= y)
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
