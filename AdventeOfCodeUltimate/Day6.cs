using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeUltimate
{
    class Day6 : IAdventOfCode
    {
        public void DoTask()
        {
            ReadInput();
           // throw new NotImplementedException();
        }
        public void ReadInput()
        {

            string fileName = "G:\\Advent Of Code 2020\\AdventeOfCodeUltimate\\AdventeOfCodeUltimate\\Input6.txt";
            string[] lines = File.ReadLines(fileName).ToArray();
            bool[] boolArray = new bool[26];

            int rightAnswers = 0;

            for (int i = 0; i < lines.Length; i++)
            {


                if (string.IsNullOrWhiteSpace(lines[i]))
                {
                    rightAnswers += boolArray.Where(v => v == true).Count();
                    boolArray = new bool[26];
                }
                else
                {
                    foreach (var character in lines[i])
                    {
                        int letterPosition = Convert.ToInt32(Char.ToUpper(character)) - 65;
                        if (boolArray[letterPosition] == false)
                        {
                            boolArray[letterPosition] = true;
                        }

                    }
                }


            }
            Console.WriteLine(rightAnswers);

            int sum2 = 0;
            List<char> magicCharsList = lines[0].ToList<char>();
          
            //2
            for (int i = 0; i < lines.Length; i++)
            {


                if (string.IsNullOrWhiteSpace(lines[i]))
                {

                    if (i + 1 <= lines.Length)
                    {
                        sum2 += magicCharsList.Count;
                        if (i +1  != lines.Length)
                        {
                            magicCharsList = lines[i + 1].ToList<char>();
                        }

                    }
                    
                   
                }
                else
                {
                    List<char> charsToRemove = new List<char>();
                    foreach (var character in magicCharsList)
                    {
                     if(!lines[i].Contains(character))
                        {
                            charsToRemove.Add(character);
                            
                        }

                    }
                    foreach (char item in charsToRemove)
                    {
                        magicCharsList.Remove(item);
                        
                    }
                }


            }
            Console.WriteLine(sum2);



        }
    }
}
