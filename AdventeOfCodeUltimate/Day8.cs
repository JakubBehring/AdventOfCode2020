using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeUltimate
{
    class Day8 : IAdventOfCode
    {
        public void DoTask()
        {
            string fileName = "G:\\Advent Of Code 2020\\AdventeOfCodeUltimate\\AdventeOfCodeUltimate\\Input8.txt";
            var lines = File.ReadLines(fileName).ToArray();
            Task1(lines);
            Task2();

        }


        public void Task1(string[] lines, bool task2Active = true)
        {

            int acc = 0;
            bool breakNeed = false;

            List<int> linesVisited = new List<int>();
            for (int i = 0; i < lines.Length;)
            {
                if (linesVisited.Contains(i))
                {
                    breakNeed = true;
                    break;
                }
                var functionAndNumber = lines[i].Split(" ");  // func +number
                var operand = functionAndNumber[1][0];   // + or -
                var number = Convert.ToInt32(functionAndNumber[1].Substring(1));

                number = operand == '-' ? number * (-1) : number;
                switch (functionAndNumber[0])
                {
                    case "acc":
                        acc += number;
                        linesVisited.Add(i);
                        i++;
                        break;
                    case "jmp":
                        linesVisited.Add(i);
                        i += number;
                        break;
                    case "nop":
                        linesVisited.Add(i);
                        i++;
                        break;

                    default:
                        break;
                }


            }

            if (task2Active)
            {
                Console.WriteLine(acc);
            }
            else if (!breakNeed)
            {
                Console.WriteLine(acc);
            }
        }

        void Task2()
        {
            string fileName = "G:\\Advent Of Code 2020\\AdventeOfCodeUltimate\\AdventeOfCodeUltimate\\Input8.txt";
            var lines = File.ReadLines(fileName).ToArray();


            // swap jmp to nop
            string swapFrom = "jmp";
            string swapTo = "nop";

            List<LineIndex> lineIndices = new List<LineIndex>();
            for (int i = 0; i < lines.Length; i++)
            {

                // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                if (lines[i].StartsWith(swapFrom))   //  add && !lines[i].Contains("+0") && !lines[i].Contains("-0")
                                                     // if you do swap from nop to jmp 
                                                     // extra AND wont hurt in case swap jmp to nop but it should not be there
                {
                    LineIndex lineIndex = new LineIndex();
                    lineIndex.Line = lines[i];
                    lineIndex.Index = i;
                    lineIndices.Add(lineIndex);

                }

            }
            foreach (var item in lineIndices) // brute force asf
            {
                string[] linesChangable = new string[lines.Length];
                lines.CopyTo(linesChangable, 0);

                int index = item.Index;
                linesChangable[index] = linesChangable[index].Replace(swapFrom, swapTo);
                // linesChangable[item.Index] = swapTo + item.Line.Substring(3);
                Task1(linesChangable, false);
            }





        }

        public class LineIndex
        {
            public string Line;
            public int Index;

        }
    }

}



