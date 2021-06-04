using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeUltimate
{
    class Day17 : IAdventOfCode
    {
        bool[,,] cubes = new bool[8, 8, 8];
        public void DoTask()
        {
            ReadInput();
            Task1();
        }
        public void Task1()
        {
           
        }
        public void ReadInput()
        {
            string fileName = "G:\\Advent Of Code 2020\\AdventeOfCodeUltimate\\AdventeOfCodeUltimate\\Input17.txt";
            var lines = File.ReadLines(fileName).ToArray();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (lines[i][j] == '#')
                        cubes[1,i,j] = true;
                }
            }
        }
        public class Cube
        {
            public bool state { get; set; }
        }
        public class Dimension
        {

        }
    }
}
