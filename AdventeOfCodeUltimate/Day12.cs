using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeUltimate
{
    class Day12 : IAdventOfCode
    {
        public void DoTask()
        {
          //  Task1();
            Task2();
            //  throw new NotImplementedException();
        }
        public void Task1()
        {
            string fileName = "G:\\Advent Of Code 2020\\AdventeOfCodeUltimate\\AdventeOfCodeUltimate\\Input12.txt";
            var lines = File.ReadLines(fileName).ToArray();
            Ferry ferry = new Ferry();
            foreach (var item in lines)
            {
                char direction = item[0];
                int value = Convert.ToInt32(item.Substring(1));
                switch (direction)
                {
                    case 'N':
                        ferry.y += value;
                        break;
                    case 'S':
                        ferry.y -= value;

                        break;
                    case 'E':
                        ferry.x += value;
                        break;
                    case 'W':
                        ferry.x -= value;
                        break;
                    case 'L':
                        {
                            int rotation = value / 90;
                            int valueToRotate = (int)ferry.direction - rotation;
                            if (valueToRotate < 0)
                            {
                                valueToRotate = Math.Abs(valueToRotate);

                                valueToRotate = valueToRotate % 4;
                                if (valueToRotate == 3)
                                {
                                    ferry.direction = Direction.north;
                                }
                                else if (valueToRotate == 1)
                                {
                                    ferry.direction = Direction.south;
                                }
                                else
                                {
                                    ferry.direction = (Direction)valueToRotate;
                                }
                                continue;


                            }
                            valueToRotate %= 4;
                            ferry.direction = (Direction)valueToRotate;
                        }

                        break;
                    case 'R':
                        {
                            int rotation = value / 90;
                            int valueToRotate = (int)ferry.direction + rotation;
                            valueToRotate %= 4;

                            ferry.direction = (Direction)valueToRotate;
                        }

                        break;
                    case 'F':
                        switch (ferry.direction)
                        {
                            case Direction.west:
                                ferry.x -= value;
                                break;
                            case Direction.north:
                                ferry.y += value;
                                break;
                            case Direction.east:
                                ferry.x += value;
                                break;
                            case Direction.south:
                                ferry.y -= value;
                                break;
                            default:
                                break;
                        }
                        break;

                    default:
                        break;
                }
            }
            Console.WriteLine($"y = {ferry.y}, x = {ferry.x}");
            Console.WriteLine(Math.Abs(ferry.x) + Math.Abs(ferry.y));


        }
        
        public void Task2()
        {
            
            string fileName = "G:\\Advent Of Code 2020\\AdventeOfCodeUltimate\\AdventeOfCodeUltimate\\Input12.txt";
            var lines = File.ReadLines(fileName).ToArray();
            (double x, double y) pos = (0d, 0d);
            (double x, double y) waypoint = (10d, -1d);

            static (double x, double y) RotateVector((double x, double y) start, double angle) =>
                (Math.Cos(angle) * start.x - Math.Sin(angle) * start.y, Math.Sin(angle) * start.x + Math.Cos(angle) * start.y);

            foreach (var move in lines)
            {
                var arg = double.Parse(move[1..]);
                switch (move[0])
                {
                    case 'N':
                        waypoint = (waypoint.x, waypoint.y + arg * -1);
                        break;
                    case 'S':
                        waypoint = (waypoint.x, waypoint.y + arg);
                        break;
                    case 'E':
                        waypoint = (waypoint.x + arg, waypoint.y);
                        break;
                    case 'W':
                        waypoint = (waypoint.x + arg * -1, waypoint.y);
                        break;
                    case 'F':
                        pos = (pos.x + waypoint.x * arg, pos.y + waypoint.y * arg);
                        break;
                    case 'R':
                        waypoint = RotateVector(waypoint, arg * Math.PI / 180);
                        break;
                    case 'L':
                        waypoint = RotateVector(waypoint, arg * Math.PI / -180);
                        break;
                }
            }

            Console.WriteLine( Math.Abs((int)Math.Round(pos.x, 0)) + Math.Abs((int)Math.Round(pos.y, 0)));
        }
    }

    public class Ferry
    {
        public Ferry(int x = 0, int y = 0,Direction direction = Direction.east)
        {
            this.x = x;
            this.y = y;
        }
        public int x;
        public int y;
        public Direction direction = Direction.east;


    }
    public enum Direction
    {
        west = 0, north, east, south
    }
}
