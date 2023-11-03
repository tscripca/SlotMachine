//using slotMachine;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SlotMachine
//{
//    public static class LogicMethods
//    {
//        public static void GameModes()
//        {
//            int winningRowCount = 0;
//            if (gameModEnum == GameMode.horizontal)
//            {
//                for (int rowIndex = 0; rowIndex < betAmount; rowIndex++)
//                {
//                    bool numbersMatch = true;
//                    for (int columnIndex = 0; columnIndex < slotMachine.GetLength(1); columnIndex++)
//                    {
//                        if (slotMachine[rowIndex, 0] != slotMachine[rowIndex, columnIndex])
//                        {
//                            numbersMatch = false;
//                            break;
//                        }
//                    }
//                    if (numbersMatch)
//                    {
//                        winningRowCount++;
//                    }
//                }
//            }
//            if (gameModEnum == GameMode.vertical)
//            {
//                for (int columnIndex = 0; columnIndex < betAmount; columnIndex++)
//                {
//                    bool numbersMatch = true;
//                    for (int rowIndex = 0; rowIndex < slotMachine.GetLength(0); rowIndex++)
//                    {
//                        if (slotMachine[0, columnIndex] != slotMachine[rowIndex, columnIndex])
//                        {
//                            numbersMatch = false;
//                            break;
//                        }
//                    }
//                    if (numbersMatch)
//                    {
//                        winningRowCount++;
//                    }
//                }
//            }
//            if (gameModEnum == GameMode.diagonal)
//            {
//                int matchingDiagonalNumbers = 0;
//                //checking the 1st diagonal
//                for (int rowIndex = 0; rowIndex < slotMachine.GetLength(0); rowIndex++)
//                {
//                    bool numbersMatch = true;
//                    for (int columnIndex = rowIndex; columnIndex <= rowIndex; columnIndex++)
//                    {
//                        if (slotMachine[0, 0] != slotMachine[rowIndex, columnIndex])
//                        {
//                            numbersMatch = false;
//                            break;
//                        }
//                    }
//                    if (numbersMatch)
//                    {
//                        matchingDiagonalNumbers++;
//                    }
//                }
//                if (matchingDiagonalNumbers >= slotMachine.GetLength(1))
//                {
//                    winningRowCount++;
//                }
//                matchingDiagonalNumbers = 0;
//                //checking 2nd diagonal
//                for (int rowIndex = 0; rowIndex < slotMachine.GetLength(0); rowIndex++)
//                {
//                    bool numbersMatch = true;
//                    int randomValue = 0;
//                    for (int columnIndex = lastColumnIndex - rowIndex; columnIndex >= randomValue; columnIndex--)
//                    {
//                        if (slotMachine[0, lastColumnIndex] != slotMachine[rowIndex, columnIndex])
//                        {
//                            numbersMatch = false;
//                        }
//                        randomValue = slotMachine.GetLength(1);
//                    }
//                    if (numbersMatch)
//                    {
//                        matchingDiagonalNumbers++;
//                    }
//                }
//                if (matchingDiagonalNumbers >= slotMachine.GetLength(1))
//                {
//                    winningRowCount++;
//                }
//            }
//        }
//        public static void PrintOutSlotMachine()
//        {
//            int rndNum = 0;
//            for (int rowIndex = 0; rowIndex < slotMachine.GetLength(0); rowIndex++)
//            {
//                for (int columnIndex = 0; columnIndex < slotMachine.GetLength(1); columnIndex++)
//                {
//                    rndNum = rng.Next(0, UPPPER_BOUND);
//                    slotMachine[rowIndex, columnIndex] = rndNum;
//                    Console.Write(rndNum + " ");
//                }
//                Console.WriteLine();
//            }
//        }
//    }
//}
