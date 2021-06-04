using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeUltimate
{
    class Day10 : IAdventOfCode
    {
        int[] Adapters;
        public void DoTask()
        {
            Task1();
            Task2();
         //   throw new NotImplementedException();
        }
        public void Task1()
        {
            string fileName = "G:\\Advent Of Code 2020\\AdventeOfCodeUltimate\\AdventeOfCodeUltimate\\Input10.txt";
            var lines = File.ReadLines(fileName).ToArray();
             Adapters = new int[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                Adapters[i] = Convert.ToInt32(lines[i]);
            }

            var adapters = Adapters.ToList<int>();
            adapters.Sort();
            adapters.Insert(0, 0);
            adapters.Add(adapters[adapters.Count - 1] + 3);



            var oneCount = 0;
            var threeCount = 0;
            foreach (var i in Enumerable.Range(0, adapters.Count - 1))
            {
                if (adapters[i + 1] - adapters[i] == 1)
                    oneCount++;
                else if (adapters[i + 1] - adapters[i] == 3)
                    threeCount++;
            }
            Console.WriteLine(oneCount * threeCount);

        }
        public void Task2()
        {
            var adapters = Adapters.ToList<int>();
            adapters.Sort();
            adapters.Insert(0, 0);
            adapters.Add(adapters[adapters.Count - 1] + 3);

            var ways = new long[adapters.Count];
            foreach (var index in Enumerable.Range(0, ways.Length))
            {
                if (index == 0)
                    ways[index] = 1;
                else
                {
                    ways[index] = 0;
                    for (var j = index - 1; j >= 0; j--)
                    {
                        if (adapters[index] - adapters[j] <= 3)
                            ways[index] += ways[j];
                        else
                            break;
                    }
                }
            }
            Console.WriteLine(ways[ways.Length-1]);
            //return ways[ways.Length - 1];

        }

    }

}
