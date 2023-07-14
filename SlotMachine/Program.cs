using System;
namespace SlotMachine // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rng = new Random();
            int randomNumberOne = rng.Next(0, 10);
            int randomNumberTwo = rng.Next(0, 10);
            int randomNumberThree = rng.Next(0, 10);
            int randomNumberFour = rng.Next(0, 10);
            int randomNumberFive = rng.Next(0, 10);
            int randomNumberSix = rng.Next(0, 10);
            int randomNumberSeven = rng.Next(0, 10);
            int randomNumberEight = rng.Next(0, 10);
            int randomNumberNine = rng.Next(0, 10);

            int[,] slotMachine = new int[3, 3];

            //top row
            slotMachine[0, 0] = randomNumberOne;//--should be a random generated number
            slotMachine[0, 1] = randomNumberTwo;
            slotMachine[0, 2] = randomNumberThree;

            //middle row
            slotMachine[1, 0] = randomNumberFour;
            slotMachine[1, 1] = randomNumberFive;
            slotMachine[1, 2] = randomNumberSix;

            //bottom row
            slotMachine[2, 0] = randomNumberSeven;
            slotMachine[2, 1] = randomNumberEight;
            slotMachine[2, 2] = randomNumberNine;

            for (int i = 0; i < slotMachine.Length; i++)
            {
                for (int j = 0; j < slotMachine.Length; j++)
                {
                    Console.Write(slotMachine[i, j]);
                }
                Console.WriteLine();
            }

        }
    }
}