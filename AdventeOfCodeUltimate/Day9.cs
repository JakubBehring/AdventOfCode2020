using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeUltimate
{
    class Day9 : IAdventOfCode
    {
        private long[] input;
        long invalidNumber = 0;
        public void DoTask()
        {
            readInput();
            Task1();
            Task2();
            //  throw new NotImplementedException();
        }

        private void readInput()
        {
            string fileName = "G:\\Advent Of Code 2020\\AdventeOfCodeUltimate\\AdventeOfCodeUltimate\\Input9.txt";
            var lines = File.ReadLines(fileName).ToArray();
            input = new long[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                input[i] = Convert.ToInt64(lines[i]);
            }
        }
        public void Task1()
        {
            for (int i = 25; i < input.Length; i++)
            {
                if (!sumIsPosible(input[i], i))
                {
                    invalidNumber = input[i];
                }

            }

            Console.WriteLine(invalidNumber);

        }

        bool sumIsPosible(long number, int index)
        {
            for (int i = index - 25; i < index; i++)
            {
                for (int j = i +1; j < index; j++)
                {
                    if (input[i] + input[j] == number && input[i] != input[j])
                        return true;
                }
            }
            return false;
        }

        public void Task2()
        {
            long numberSum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                numberSum += input[i];

                for (int j = i+1; j < input.Length; j++)
                {
                    numberSum += input[j];
                    if(numberSum == invalidNumber && input[i] != invalidNumber)
                    {
                        findMinAndMax(i, j);
                    }
                    if(numberSum > invalidNumber)
                    {
                        numberSum = 0;
                        break;
                    }
                }
            }
        }
        void findMinAndMax(int index1, int index2)
        {
            long min = long.MaxValue;
            long max = long.MinValue;
            for (int i = index1; i <index2; i++)
            {
                if (input[i] < min)
                    min = input[i];
                if (input[i] > max)
                    max = input[i];
            }
            Console.WriteLine(min + max);
        }
       

       
    }
}
