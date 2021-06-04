using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeUltimate
{
    class Day3 : IAdventOfCode
    {
        public void DoTask()
        {
            // task 1
            Console.WriteLine(GetTreesCount(3,1));

            // task 2 
            long value2 = 1;
            var tab = new[] { new { r = 1, d = 1 }, new { r = 3, d = 1 },
                new { r = 5, d = 1 }, new { r = 7, d = 1 }, new { r = 1, d = 2 } };

            foreach (var item in tab)
            {
                int trees = GetTreesCount(item.r, item.d);
                value2 *= trees;
            }
           
            Console.WriteLine(value2);

        }
        public int GetTreesCount(int xMove, int yMove)
        {
            var input = GetInputToCharTab();
            int lineCount = input.Length;
            int treesCount = 0;
            int x = xMove, y = yMove;

            // task1
            while (y < lineCount)
            {
              int  lineLenght = input[y].Length;
                if (input[y][x] == '#')
                {
                    treesCount++;
                }
                y += yMove;
                x += xMove;
                x = x % lineLenght;

            }
           
            return treesCount;
        }

        public char[][] GetInputToCharTab()
        {
            string fileName = "G:\\Advent Of Code 2020\\AdventeOfCodeUltimate\\AdventeOfCodeUltimate\\Input3.txt";
            string[] LINES = File.ReadLines(fileName).ToArray();
            int howManyLines = LINES.Length;
            int lineLenght = LINES[0].Length;
            char[][] tabToReturn = new char[howManyLines][];
            for (int i = 0; i < howManyLines; i++)
            {
                tabToReturn[i] = new char[lineLenght];
                for (int j = 0; j < lineLenght; j++)
                {
                    tabToReturn[i][j] = LINES[i][j];
                }
            }

            return tabToReturn;
        }
    }
}
//if (input[y][x] == '#')
//{
//    treesCount++;
//}
//y++;
//if (goingRight == true)
//{
//    x += 3;
//}
//else
//{
//    x -= 3;
//}

//if (x + 3 > lineLenght)
//{
//    goingRight = false;

//}
//if (x - 3 < 0)
//{
//    goingRight = true;
//}