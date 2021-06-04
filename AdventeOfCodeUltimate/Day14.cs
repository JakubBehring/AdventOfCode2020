using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeUltimate
{
    class Day14 : IAdventOfCode
    {
        List<ObjectInMemory> listOfAdress = new List<ObjectInMemory>();
        public void DoTask()
        {
            Task1();
            Task2();
          
        }

        public void Task1()
        {
            listOfAdress = new List<ObjectInMemory>();
            string fileName = "G:\\Advent Of Code 2020\\AdventeOfCodeUltimate\\AdventeOfCodeUltimate\\Input14.txt";
            var lines = File.ReadLines(fileName).ToArray();
            string mask = "";

            foreach (var item in lines)
            {
                if (item.StartsWith("mask"))
                {
                    mask = item.Substring(7);
                    int value = mask.Length;
                }
                else
                {
                    var indexOfCLosingBracket = item.IndexOf(']');

                    var memoryAdress = Convert.ToInt32(item.Substring(4, indexOfCLosingBracket - 4));
                    var value = Convert.ToInt32(item.Substring(indexOfCLosingBracket + 3));
                    AddValueToMemory(memoryAdress, value, mask);
                }
            }
            long sum = 0;
            foreach (var item in listOfAdress)
            {
                sum += item.value;
            }
            Console.WriteLine(sum);
        }
        public void Task2()
        {
            listOfAdress = new List<ObjectInMemory>();
            string fileName = "G:\\Advent Of Code 2020\\AdventeOfCodeUltimate\\AdventeOfCodeUltimate\\Input14.txt";
            var lines = File.ReadLines(fileName).ToArray();
            string mask = "";

            foreach (var item in lines)
            {
                if (item.StartsWith("mask"))
                {
                    mask = item.Substring(7);
                }
                else
                {
                    var indexOfCLosingBracket = item.IndexOf(']');
                    //                                                    01234              
                    //                                                    mem[9876] =  1234567 
                    var memoryAdress = Convert.ToInt32(item.Substring(4, indexOfCLosingBracket - 4));
                    var value = Convert.ToInt32(item.Substring(indexOfCLosingBracket + 3));
                    AddValueToMemoryTask2(memoryAdress, value, mask);
                }
            }
            long sum = 0;
            foreach (var item in listOfAdress)
            {
                sum += item.value;
            }
            Console.WriteLine(sum);
        }

        public void AddValueToMemory(long memoryAdress, long value, string mask)
        {
            var valueConvertedToBinary36 = ConvertDecimalToBinary36(value).ToCharArray();
            for (int i = 0; i < valueConvertedToBinary36.Length; i++)
            {
                if (mask[i] == '1')
                {
                    if (valueConvertedToBinary36[i] == '0')
                        valueConvertedToBinary36[i] = '1';

                }
                else if (mask[i] == '0')
                {
                    if (valueConvertedToBinary36[i] == '1')
                        valueConvertedToBinary36[i] = '0';
                }

            }
            var ObjectToInspect = listOfAdress.Find(x => x.address == memoryAdress);
            if (ObjectToInspect != null)
            {

                ObjectToInspect.value = ConvertBinary36ToDecimal(new string(valueConvertedToBinary36));

            }
            else
            {
                ObjectInMemory objectInMemory = new ObjectInMemory();

                objectInMemory.value = ConvertBinary36ToDecimal(new string(valueConvertedToBinary36));
                objectInMemory.address = memoryAdress;
                listOfAdress.Add(objectInMemory);
            }

        }
        public void AddValueToMemoryTask2(long memoryAdress, long value, string mask)
        {
            var AddressConvertedToBinary36 = ConvertDecimalToBinary36(memoryAdress).ToCharArray();
            int HowManyX = 0;
            for (int i = 0; i < AddressConvertedToBinary36.Length; i++)
            {
                if (mask[i] == '1')
                {
                    if (AddressConvertedToBinary36[i] == '0')
                        AddressConvertedToBinary36[i] = '1';

                }
                else if (mask[i] == 'X')
                {
                    HowManyX++;
                    AddressConvertedToBinary36[i] = 'X';
                }

            }
            // need to proced X in adress somehow
            var adresses = GenereteAddresses(new string(AddressConvertedToBinary36), HowManyX);
            

            for (int i = 0; i < adresses.Count; i++)
            {
                memoryAdress = adresses[i];

                var ObjectToInspect = listOfAdress.Find(x => x.address == memoryAdress);
               
                if (ObjectToInspect != null)
                {
                    ObjectToInspect.value = value;
                }
                else
                {
                    ObjectInMemory objectInMemory = new ObjectInMemory();

                    objectInMemory.value = value;
                    objectInMemory.address = memoryAdress;
                    listOfAdress.Add(objectInMemory);
                }
            }

        }
        public List<long> GenereteAddresses(string addressWithX, int howManyX)
        {
            List<long> AddressesToReturn = new List<long>();
            // will genere combinations
            // 000, 001, 010,011...
            int combinationsCount = (int)Math.Pow(2, howManyX);
            string[] Combinations = new string[combinationsCount];
            for (int i = 0; i < combinationsCount; i++)
            {
                Combinations[i] = ConvertDecimalToBinary36(i);

            }

            for (int i = 0; i < combinationsCount; i++)
            {
                var temporraryAdress = addressWithX.ToCharArray();
                // its 36 binary system 
                //k is index which we swaping from combinaction
                for (int j = 35, k = 0; j >= 0; j--)
                {
                    if (temporraryAdress[j] == 'X')
                    {
                        temporraryAdress[j] = Combinations[i][35 - k];
                        k++;
                        if (k > howManyX)
                            break;

                    }
                }
                AddressesToReturn.Add(ConvertBinary36ToDecimal(new string(temporraryAdress)));

            }
            return AddressesToReturn;
        }
        public string ConvertDecimalToBinary36(long decimalValue)
        {
            string converted = Convert.ToString(decimalValue, 2);
            int zerosAddedLength = 36 - converted.Length;
            string zeros = new string('0', zerosAddedLength);
            return zeros + converted;
        }

        public long ConvertBinary36ToDecimal(string binaryValue) => Convert.ToInt64(binaryValue, 2);
    }
    public class ObjectInMemory
    {
        public long address { get; set; }
        public long value { get; set; }
    }
}
