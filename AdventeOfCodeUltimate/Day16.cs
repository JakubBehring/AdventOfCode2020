using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeUltimate
{
    class Day16 : IAdventOfCode
    {
      public  string[] Rules { get; set; }
        public string[] NearbyTickets { get; set; }
        public string MyTicket { get; set; }
        private const int maxNumber = 1000;
        public int[] ValidNumbers = new int[1000];
        public List<string> ValidTickets = new List<string>();
        public string[] ValidTicketsTab;
        
        public void DoTask()
        {
            ReadInput();
            initializeInvalidNumbers();
           Task1();
            Task2();
           

      
        }

        public void Task1()
        {
            int scanningErrorRate = 0;
            foreach (var numbersString in NearbyTickets)
            {
                int[] numbersInt = numbersString.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
                bool TicketIsvalid = true;
                foreach (var number in numbersInt)
                {
                    if(ValidNumbers[number] == -1)
                    {
                        scanningErrorRate += number;
                        TicketIsvalid = false;
                    }
                }
                if(TicketIsvalid)
                {
                    ValidTickets.Add(numbersString);
                }
            }
            ValidTicketsTab = ValidTickets.ToArray();
            Console.WriteLine(scanningErrorRate);
        }
        public void Task2()
        {
            Dictionary<int, string> IndexRule = new Dictionary<int, string>();

            // we chck all rules
            for (int i = 0; i < 20; i++)
            {
                var ruleToCheck = Rules[i];
                string onlyNumbersAndOr = ruleToCheck.Split(':', StringSplitOptions.TrimEntries)[1];
                var ranges = onlyNumbersAndOr.Split("or", StringSplitOptions.TrimEntries);
                int min1 = Convert.ToInt32(ranges[0].Split('-')[0]);
                int max1 = Convert.ToInt32(ranges[0].Split('-')[1]);
                int min2 = Convert.ToInt32(ranges[1].Split('-')[0]);
                int max2 = Convert.ToInt32(ranges[1].Split('-')[1]);


                // in each kolumn
                for (int j = 0; j < 20; j++)
                {
                  
                    bool allNumberMatcheRule = true;
                    //in each Ticket
                    for (int k = 0; k < ValidTicketsTab.Length; k++)
                    {
                        var numbers = ValidTicketsTab[k].Split(",").Select(n => Convert.ToInt32(n)).ToArray();
                        if (!((numbers[j] >= min1 && numbers[j] <= max1) || (numbers[j] >= min2 && numbers[j] <= max2)))
                        {
                            allNumberMatcheRule = false;
                            break;
                        }
                        
                    }

                    if(allNumberMatcheRule)
                    {
                        if (!IndexRule.ContainsKey(j))
                        {
                            IndexRule.Add(j, ruleToCheck);
                            break;
                        }
                        
                      
                    }
                }
            }
          
            long value = 1;
            var numbers2 = MyTicket.Split(",").Select(n => Convert.ToInt32(n)).ToArray();
            var d = IndexRule.Where(v => v.Value.StartsWith("departure"));
            foreach (var item in d)
            {
                value *= MyTicket[item.Key];
               
            }
            Console.WriteLine(value);
          







        }
        public void ReadInput()
        {
            string fileName = "G:\\Advent Of Code 2020\\AdventeOfCodeUltimate\\AdventeOfCodeUltimate\\Input16.txt";
            var lines = File.ReadAllText(fileName);
            var linesSplited = lines.Split("your ticket:", StringSplitOptions.TrimEntries);
            var linesSplited2 = linesSplited[1].Split("nearby tickets:", StringSplitOptions.TrimEntries);

             Rules = linesSplited[0].Split("\r\n");
            MyTicket = linesSplited2[0];
             NearbyTickets = linesSplited2[1].Split("\r\n");


            
        }
        public void initializeInvalidNumbers()
        {
            for (int i = 0; i < ValidNumbers.Length; i++)
            {
                ValidNumbers[i] = -1;
            }
            foreach (var item in Rules)
            {
                string onlyNumbersAndOr = item.Split(':', StringSplitOptions.TrimEntries)[1];
                var ranges = onlyNumbersAndOr.Split("or", StringSplitOptions.TrimEntries);
                int min1 = Convert.ToInt32(ranges[0].Split('-')[0]);
                int max1 = Convert.ToInt32(ranges[0].Split('-')[1]);
                int min2 = Convert.ToInt32(ranges[1].Split('-')[0]);
                int max2  = Convert.ToInt32(ranges[1].Split('-')[1]);
                for (int i = min1; i <= max1; i++)
                {
                    ValidNumbers[i] = 1;
                }
                for (int i = min2; i <= max2; i++)
                {
                    ValidNumbers[i] = 1;
                }

            }
          
        }



    }
}
