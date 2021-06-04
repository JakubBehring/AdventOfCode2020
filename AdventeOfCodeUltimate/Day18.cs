using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeUltimate
{
    class Day18 : IAdventOfCode
    {
        Dictionary<char, int> operandsImportance = new Dictionary<char, int>()
        {

            {'(',0 },
           {'-',1},  { '+', 1 },
           {'/',2} ,{'*',2},



        };


        public void DoTask()
        {
            Task1();
            Task2();
        }

        public void Task1()
        {
            operandsImportance = new Dictionary<char, int>()
        {
            {'(',0 },
            {'*',1},
            { '+', 1 }
        };


            string fileName = "G:\\Advent Of Code 2020\\AdventeOfCodeUltimate\\AdventeOfCodeUltimate\\Input18.txt";
            var lines = File.ReadLines(fileName).ToArray();
            double sum = 0;

            foreach (var line in lines)
            {
                var operandsAndOperatos = line.ToCharArray().Where(c => !char.IsWhiteSpace(c)).ToArray();
                var RPN_Array = GetReversePolishNotation(operandsAndOperatos);
                sum += RPN_ToValue(RPN_Array);
            }
            Console.WriteLine(sum);
        }

        public void Task2()
        {
            operandsImportance = new Dictionary<char, int>()
            {
                {'(',0 },
                {'*',1},
                { '+', 2 }
            };
            string fileName = "G:\\Advent Of Code 2020\\AdventeOfCodeUltimate\\AdventeOfCodeUltimate\\Input18.txt";
            var lines = File.ReadLines(fileName).ToArray();
            double sum = 0;

            foreach (var line in lines)
            {
                var operandsAndOperatos = line.ToCharArray().Where(c => !char.IsWhiteSpace(c)).ToArray();
                var RPN_Array = GetReversePolishNotation(operandsAndOperatos);
                sum += RPN_ToValue(RPN_Array);
            }
            Console.WriteLine(sum);
        }


        public char[] GetReversePolishNotation(char[] operandsAndOperatos)
        {
            Stack<char> stack = new Stack<char>();
            List<char> listToReversePolishNotation = new List<char>();

            foreach (var item in operandsAndOperatos)
            {
                if (char.IsDigit(item))
                {
                    listToReversePolishNotation.Add(item);
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        stack.Push(item);
                        continue;
                    }

                    if (item == '(')
                    {
                        stack.Push(item);
                        continue;
                    }

                    if (item == ')')
                    {
                        while (true)
                        {
                            char itemPoped = stack.Peek();
                            if (itemPoped == '(')
                            {
                                stack.Pop();
                                break;
                            }
                            else
                            {
                                listToReversePolishNotation.Add(itemPoped);
                                stack.Pop();
                            }
                        }
                        continue;
                    }
                    char operatorPeek = stack.Peek();
                    if (operandsImportance[item] > operandsImportance[operatorPeek])
                    {
                        stack.Push(item);
                        continue;
                    }
                    else
                    {

                        while (stack.Count > 0 && operandsImportance[item] <= operandsImportance[stack.Peek()])
                        {
                            listToReversePolishNotation.Add(stack.Pop());
                        }

                        stack.Push(item);
                    }



                }
            }
            while (stack.Count > 0)
            {
                listToReversePolishNotation.Add(stack.Pop());
            }
            return listToReversePolishNotation.ToArray<char>();

        }
        public long RPN_ToValue(char[] RPN_Array)
        {

            Stack<long> stackValues = new Stack<long>();

            foreach (var item in RPN_Array)
            {
                if (char.IsDigit(item))
                {
                    stackValues.Push(Convert.ToInt64(item.ToString()));
                }
                else
                {

                    long firstOperand = stackValues.Pop();
                    long SecondOperand = stackValues.Pop();
                    long value;
                    switch (item)
                    {
                        case '+':
                            value = firstOperand + SecondOperand;
                            stackValues.Push(value);
                            break;



                        case '*':
                            value = firstOperand * SecondOperand;
                            stackValues.Push(value);
                            break;
                        default:
                            break;
                    }

                }
            }

            return stackValues.Pop();



            //for (int i = RPN_Array.Length-1; i >= 0; i--)
            //{
            //    if (char.IsDigit(RPN_Array[i]))
            //    { 
            //        stackNumbers.Push(Convert.ToInt32(RPN_Array[i].ToString())); 
            //    }
            //    else
            //    {
            //        stackOperators.Push(RPN_Array[i]);
            //    }


            //}
            //while (stackNumbers.Count > 1)
            //{
            //    int firstOperand =Int32.Parse( stackNumbers.Pop().ToString());

            //    int SecondOperand = Int32.Parse(stackNumbers.Pop().ToString());
            //    int value;


            //    switch (stackOperators.Pop())
            //    {
            //        case '+':
            //            value = firstOperand + SecondOperand;
            //            stackNumbers.Push(value);
            //            break; 
            //        case '-':
            //            value = firstOperand - SecondOperand;
            //            stackNumbers.Push(value);
            //            break;

            //        case '/':
            //            value = firstOperand / SecondOperand;
            //            stackNumbers.Push(value);
            //            break;

            //        case '*':
            //            value = firstOperand * SecondOperand;
            //            stackNumbers.Push(value);
            //            break;
            //        default:
            //            break;
            //    }


            //}
            //return Convert.ToInt32(stackNumbers.Pop());



        }







    }
}