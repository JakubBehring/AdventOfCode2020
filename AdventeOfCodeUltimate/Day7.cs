using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeUltimate
{
    class Day7 : IAdventOfCode
    {
        string[] lines;
        List<string> ColorsChecked = new List<string>();
        double valueForTaskTwo = 0;
        public void DoTask()
        {
            ReadInput();
            //  throw new NotImplementedException();
        }
        public void ReadInput()
        {
            string fileName = "G:\\Advent Of Code 2020\\AdventeOfCodeUltimate\\AdventeOfCodeUltimate\\Input7.txt";
            lines = File.ReadLines(fileName).ToArray();
            List<string> colors = new List<string>();
            foreach (var item in lines)
            {
                var splitedLine = item.Split(" ");
                string color = splitedLine[0] + " " + splitedLine[1];
                colors.Add(color);
            }

           HowMany("shiny gold");
            Console.WriteLine(ColorsChecked.Count);

            //part 2
            string partTwoString = lines.Where(s => s.StartsWith("shiny gold")).FirstOrDefault();
            HowMany2(partTwoString);
            Console.WriteLine(valueForTaskTwo);
     
         
        }
        public void HowMany(string color)
        {
            //lines where has that color AND dont are this color by itself AND that line does not conains color that m8 has color that conains gold 
            var colors = lines.Where(s => s.Contains(color) && !s.StartsWith(color) && !ColorsChecked.Contains(s)).ToArray();
            ColorsChecked.AddRange(colors);
            for (int i = 0; i < colors.Length; i++)
            {
                string[] splited = colors[i].Split(" ");
                if (splited.Length != 0)
                {
                    string toSend = splited[0] + " " + splited[1];
                    HowMany(toSend);
                 }
             
            }
           

           
        }
        double sum = 0;
        public void HowMany2(string color)
        {
            string[] splitedByNameAndBags= color.Split("contain", StringSplitOptions.TrimEntries);
            string[] splitedByBags = splitedByNameAndBags[1].Split(",", StringSplitOptions.TrimEntries);
           
           for(int i = 0; i < splitedByBags.Length; i++)
            {
                string bag = splitedByBags[i];
              
               
                if (bag.Contains("."))
                {
                    bag = bag.Substring(0, bag.Length - 1);
                }
                double value = char.GetNumericValue(bag[0]);
               

                if (value != -1)
                    valueForTaskTwo += value;

                for (int j = 0; j < value; j++)
                {
                    string bagNameWithoutNumber = bag.Substring(2, bag.Length -2 );
                  HowMany2(lines.Where(s => s.StartsWith(bagNameWithoutNumber)).FirstOrDefault());
                }
                
               
               

            }
        }
    }
}
