using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;


namespace AdventOfCodeUltimate
{
    class Day1 : IAdventOfCode
    {
        public void DoTask()
        {
            int[] numbers = getIntTabFromInput();
            int InputCount = numbers.Length;
            int lowestNumber = int.MaxValue;
            Stopwatch stopwatch = new Stopwatch();

            // find lowest number

            foreach (var item in numbers)
            {

                if (lowestNumber > item)
                    lowestNumber = item;

            }
            //alghorithm
            stopwatch.Start();
            int a = 0, b = 0, c = 0;
            bool stop = true;
            for (int i = 0; i < InputCount && stop; i++)
            {

                if (numbers[i] + lowestNumber > 2020)
                    continue;
                for (int j = 0; j < InputCount && stop; j++)
                {
                    if (numbers[i] + lowestNumber + lowestNumber > 2020)
                        continue;
                    for (int k = 0; k < InputCount; k++)
                    {
                        if (numbers[i] + numbers[j] + numbers[k] == 2020)
                        {
                            a = numbers[i];
                            b = numbers[j];
                            c = numbers[k];
                            stop = false;
                            break;

                        }
                    }
                }

            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedTicks);
            Console.WriteLine(a + " + " + b);
            Console.WriteLine("{0} * {1} = {2}", a, b, a * b);
            Console.WriteLine("{0} + {1} + {2} = {3}", a, b, c, a + b + c);
            Console.WriteLine("{0} * {1} * {2} = {3}", a, b, c, a * b * c);
        }

        public int[] getIntTabFromInput()
        {
            string textRead;
            using (var sr = new StreamReader("G:\\Advent Of Code 2020\\AdventeOfCodeUltimate\\AdventeOfCodeUltimate\\input1.txt"))
            {
                textRead = sr.ReadToEnd();
            }

            string[] input = textRead.Split(",", StringSplitOptions.TrimEntries);
            int InputCount = input.Length;
            int[] numbers = new int[InputCount];

            for (int i = 0; i < InputCount; i++)
            {
                numbers[i] = Convert.ToInt32(input[i]);
            }

            return numbers;
        }
        public static void GetResault(int[] numbers)
        {
        }
        

        
            
    }
}
