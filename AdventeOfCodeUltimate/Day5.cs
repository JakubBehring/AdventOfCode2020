using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeUltimate
{
    class Day5 : IAdventOfCode
    {
        public int BigestNumber = int.MinValue;
        public void DoTask()
        {
            var seats = GetInput();
            //foreach (var item in seats)
            //{
            //    Console.SetCursorPosition(item.column, item.row);

            //    Console.Write("X");
            //    if(Console.GetCursorPosition().Left == 7)
            //    {
            //        Console.SetCursorPosition(item.column + 5, item.row);
            //        Console.Write("({0})",item.row);
            //    }
            //}
           

            int firstRow = seats.Min(s => s.row);
            int LastRow = seats.Max(s => s.row);
            int tabLenght = LastRow + firstRow;
            char[][] seatsChars= new char[tabLenght][];
            for (int i = 0; i < tabLenght; i++)
            {
                seatsChars[i] = new char[8];
            }

            foreach (var item in seats)
            {
                int row = item.row;
                int column = item.column;
                seatsChars[row][column] = 'X';
            }

            for(int i = firstRow+1; i <LastRow -1; i++ )
            {
                for (int j = 0; j < 8; j++)
                {
                    // null for chars
                    if( seatsChars[i][j]  == '\0')
                    {
                        Console.WriteLine();
                        Console.WriteLine("task 2 : "+ (i*8 + j));
                        Console.WriteLine();
                    }
                }
            }
            Console.WriteLine("task 1 : " + BigestNumber);
         
        }
        
        public RowColumnData[] GetInput()
        {
            string fileName = "G:\\Advent Of Code 2020\\AdventeOfCodeUltimate\\AdventeOfCodeUltimate\\Input5.txt";
            string[] lines = File.ReadLines(fileName).ToArray();
            RowColumnData[] rowColumnDatasTab = new RowColumnData[lines.Length];
            int max = int.MinValue;
            for (int i = 0; i < lines.Length; i++)
            {
                RowColumnData rowColumnData = new RowColumnData();
                var rowString = lines[i].Take(7);
                var reversedRowString = rowString.Reverse().ToArray();
                int rowValue = 0;
                for (int j = 0; j < reversedRowString.Length; j++)
                {
                    if(reversedRowString[j] == 'B')
                    {
                        rowValue += Convert.ToInt32( Math.Pow(2, j));
                    }
                }
                rowColumnData.row = rowValue;

                var columnString = lines[i].Skip(7);
                var reversedColumnString = columnString.Reverse().ToArray();
                int columnValue = 0;
                for (int j = 0; j < reversedColumnString.Length ; j++)
                {
                    if(reversedColumnString[j] == 'R')
                    {
                        columnValue += Convert.ToInt32( Math.Pow(2, j));
                    }
                }
                rowColumnData.column = columnValue;

                rowColumnData.seatID = 8 * rowValue + columnValue;
                rowColumnDatasTab[i] = rowColumnData;
                if(rowColumnData.seatID > BigestNumber)
                {
                    BigestNumber = rowColumnData.seatID;
                }
            }
            return rowColumnDatasTab;
        }
        public class RowColumnData
        {
            public int row { get; set; }
            public int column { get; set; }
            public int seatID { get; set; }
        }
    }
}
