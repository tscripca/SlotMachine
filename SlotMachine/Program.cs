using System;
namespace SlotMachine // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rng = new Random();
            int[,] slotMachine = new int[3, 3];

            for (int collumnIndex = 0; collumnIndex < slotMachine.GetLength(0); collumnIndex++)
            {  
                if(collumnIndex > 0)
                {
                    int randomCollumnNumber = rng.Next(0, 10);
                    slotMachine[collumnIndex, 0] = randomCollumnNumber;
                }
                for (int rowIndex = 0; rowIndex < slotMachine.GetLength(1); rowIndex++)
                {
                    int randomRowNumber = rng.Next(0, 10);
                    slotMachine[0, rowIndex] = randomRowNumber;
                     
                    Console.Write(randomRowNumber + " ");

                }                
                Console.WriteLine();
            }            
        }
    }
}