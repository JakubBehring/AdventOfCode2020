using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeUltimate
{
    class Day11 : IAdventOfCode
    {
        int gridHeight;
        int gridLenght;
        public void DoTask()
        {
            //int i = 0;
            //int j = 3;
            //char[][] allSeatsOriginal = ReadInput();
            //gridHeight = allSeatsOriginal.Length;
            //gridLenght = allSeatsOriginal[0].Length;
            //howManyOcupiedSeats(j, i, allSeatsOriginal);
           // Task1();
            Task2();
        }

        public void Task1()
        {

            char[][] allSeatsOriginal = ReadInput();
             gridHeight = allSeatsOriginal.Length;
             gridLenght = allSeatsOriginal[0].Length;
            
            // copy part
            char[][] allSeatsCopy = new char[gridHeight][];
            for (int i = 0; i < allSeatsCopy.Length; i++)
            {
                allSeatsCopy[i] = new char[gridLenght];
                allSeatsOriginal[i].CopyTo(allSeatsCopy[i],0);
            }
         
            bool seatChanges = true;
        
           
            while (seatChanges)
            {

                int howManySeatsChanges = 0;

                for (int i = 0; i < allSeatsOriginal.Length; i++)
                {
                    for (int j = 0;  j < allSeatsOriginal[i].Length;  j++)
                    {
                        if(allSeatsOriginal[i][j] == '.')
                        {
                            continue;
                        }
                        else if(allSeatsOriginal[i][j] == 'L')
                        {
                            int ocupiedSeats = howManyOcupiedSeats(j, i, allSeatsOriginal);
                            if(ocupiedSeats == 0)
                            {
                                allSeatsCopy[i][j] = '#';
                            
                                howManySeatsChanges++;
                            }

                        }
                        else if(allSeatsOriginal[i][j] == '#')
                        {
                            int ocupiedSeats = howManyOcupiedSeats(j, i, allSeatsOriginal);
                            if(ocupiedSeats >= 4)
                            {
                                allSeatsCopy[i][j] = 'L';
                                howManySeatsChanges++;
                            }
                        }
                    }
                }

              
                //copy part
                for (int i = 0; i < gridHeight; i++)
                {
                    allSeatsCopy[i].CopyTo(allSeatsOriginal[i],0);
                }
            

            
                if(howManySeatsChanges == 0)
                {
                    int howManyOcupited = 0;
                    seatChanges = false;

                    // check how many ocupited afer no change
                    for (int i = 0; i < gridHeight; i++)
                    {
                        for (int j = 0; j < gridLenght; j++)
                        {
                            if(allSeatsOriginal[i][j] == '#')
                            {
                                howManyOcupited++;
                            }
                        }
                    }
                    Console.WriteLine(howManyOcupited);
                }
            }
          

        }
        public void Task2()
        {
            char[][] allSeatsOriginal = ReadInput();
            gridHeight = allSeatsOriginal.Length;
            gridLenght = allSeatsOriginal[0].Length;

            // copy part
            char[][] allSeatsCopy = new char[gridHeight][];
            for (int i = 0; i < allSeatsCopy.Length; i++)
            {
                allSeatsCopy[i] = new char[gridLenght];
                allSeatsOriginal[i].CopyTo(allSeatsCopy[i], 0);
            }

            bool seatChanges = true;


            while (seatChanges)
            {

                int howManySeatsChanges = 0;

                for (int i = 0; i < allSeatsOriginal.Length; i++)
                {
                    for (int j = 0; j < allSeatsOriginal[i].Length; j++)
                    {
                        if (allSeatsOriginal[i][j] == '.')
                        {
                            continue;
                        }
                        else if (allSeatsOriginal[i][j] == 'L')
                        {
                            int ocupiedSeats = howManyOCupiedSeatsTask2(j, i, allSeatsOriginal);
                            if (ocupiedSeats == 0)
                            {
                                allSeatsCopy[i][j] = '#';

                                howManySeatsChanges++;
                            }

                        }
                        else if (allSeatsOriginal[i][j] == '#')
                        {
                            int ocupiedSeats = howManyOCupiedSeatsTask2(j, i, allSeatsOriginal);
                            if (ocupiedSeats >= 5)
                            {
                                allSeatsCopy[i][j] = 'L';
                                howManySeatsChanges++;
                            }
                        }
                    }
                }


                //copy part
                for (int i = 0; i < gridHeight; i++)
                {
                    allSeatsCopy[i].CopyTo(allSeatsOriginal[i], 0);
                }



                if (howManySeatsChanges == 0)
                {
                    int howManyOcupited = 0;
                    seatChanges = false;

                    // check how many ocupited afer no change
                    for (int i = 0; i < gridHeight; i++)
                    {
                        for (int j = 0; j < gridLenght; j++)
                        {
                            if (allSeatsOriginal[i][j] == '#')
                            {
                                howManyOcupited++;
                            }
                        }
                    }
                    Console.WriteLine(howManyOcupited);
                }
            }

        }
        public int howManyOCupiedSeatsTask2(int x, int y, char[][] seats)
        {
            int ocupiedSeats = 0;


            Point[] eightSides =
            {
             new Point(-1,-1), new Point(0,-1), new Point(1,-1),
             new Point(-1,0) , new Point(1,0),
             new Point(-1,1), new Point(0,1), new Point(1,1)
            };
            //8 fucking sides 
            for (int i = 0; i < 8; i++)
            {
                int xToMove = eightSides[i].X;
                int yToMove = eightSides[i].Y;
                while (y + yToMove >= 0 && y + yToMove < gridHeight && x + xToMove >= 0 && x + xToMove < gridLenght)
                {
                    if(seats[y+yToMove][x+xToMove] == 'L')
                    {
                        break;
                    }
                    else if (seats[y + yToMove][x + xToMove] == '#')
                    {
                        ocupiedSeats++;
                        break;
                    }
                    xToMove += eightSides[i].X;
                    yToMove += eightSides[i].Y;
                    
                }

            }
            return ocupiedSeats;
        }
        public int howManyOcupiedSeats(int x, int y, char[][] seats)
        {
            int ocupiedSeats = 0;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0)
                        continue;
                    if (y + i < 0 || y + i >= gridHeight || x + j < 0 || x + j >= gridLenght)
                        continue;
                    else if (seats[y + i][x + j] == '#')
                    {
                        ocupiedSeats++;
                    }
                }
            }
            return ocupiedSeats;
        }
        public char[][] ReadInput()
        {
            string fileName = "G:\\Advent Of Code 2020\\AdventeOfCodeUltimate\\AdventeOfCodeUltimate\\Input11.txt";
            var lines = File.ReadLines(fileName).ToArray();

            int HowManyLines = lines.Length;
            char[][] allSeats = new char[HowManyLines][];
            for (int  i = 0;  i < HowManyLines;  i++)
            {
                allSeats[i] = new char[lines[i].Length];
                allSeats[i] = lines[i].ToCharArray();

            }
            return allSeats;
        }
    }
}
