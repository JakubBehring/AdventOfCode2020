using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeUltimate
{
    class Day13 : IAdventOfCode
    {
        long startTime = 100000000000000;
        public void DoTask()
        {
            Task1();
        }

        public void Task1()
        {

            string fileName = "G:\\Advent Of Code 2020\\AdventeOfCodeUltimate\\AdventeOfCodeUltimate\\Input13.txt";
            var lines = File.ReadLines(fileName).ToArray();

            long timestamp = Convert.ToInt64(lines[0]);
            List<(long numberAdded, int id)> mylist = new List<(long numberAdded, int id)>();
            foreach (var item in lines[1].Split(","))
            {
                if (item == "x")
                    continue;
                int id = Convert.ToInt32(item);
                int multipliesCount =Convert.ToInt32( timestamp / id);
                long valueadded = id * multipliesCount + id;
                mylist.Add((valueadded, id));
            }
            long smallest = mylist.Min(x => x.numberAdded);
            long idsmallest = mylist.Where(x => x.numberAdded == smallest).FirstOrDefault().id;
            Console.WriteLine((smallest - timestamp) *  idsmallest);
        }

        public void Task2()
        {
           
        }
    }
}
