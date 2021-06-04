using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeUltimate
{
    class Day2 : IAdventOfCode
    {
        public void DoTask()
        {
            var validCounter = 0;
            var validCounterSecond = 0;
            var policyAndPasswords = GetPolicyAndPasswordFromInput();
            foreach (var papObject in policyAndPasswords)
            {
                int counter = 0;

                foreach (var passwordLetter in papObject.password)
                {
                    if (passwordLetter == papObject.letter)
                    {
                        counter++;
                    }

                }

                if (papObject.letter == papObject.password[papObject.min - 1] && papObject.letter != papObject.password[papObject.max - 1]
                    || papObject.letter != papObject.password[papObject.min - 1] && papObject.letter == papObject.password[papObject.max - 1])
                {
                    validCounterSecond++;
                }
                if (counter >= papObject.min && counter <= papObject.max)
                {
                    validCounter++;
                }

                // if for second task

            }
            Console.WriteLine(validCounter);
            Console.WriteLine(validCounterSecond);
        }

        public PolicyAndPassword[] GetPolicyAndPasswordFromInput()
        {
            string fileName = "G:\\Advent Of Code 2020\\AdventeOfCodeUltimate\\AdventeOfCodeUltimate\\Input2.txt";
            string[] LINES = File.ReadLines(fileName).ToArray();
            PolicyAndPassword[] policyAndPasswords = new PolicyAndPassword[LINES.Length];

            for (int i = 0; i < LINES.Length; i++)
            {
                int min, max;
                char letter;
                string password;

                // min- max letter : password
                var lineSplited = LINES[i].Split(':', StringSplitOptions.TrimEntries);
                password = lineSplited[1];
                // min- max letter
                letter = lineSplited[0].Last();

                var lineWithoutPassword = lineSplited[0].ToString();
                lineWithoutPassword = lineWithoutPassword.Remove(lineWithoutPassword.Length - 2);
                // min- max letter
                var lineWithoutPasswordTab = lineWithoutPassword.Split("-", StringSplitOptions.TrimEntries);
                min = Convert.ToInt32(lineWithoutPasswordTab[0]);
                max = Convert.ToInt32(lineWithoutPasswordTab[1]);

                policyAndPasswords[i] = new PolicyAndPassword() { min = min, max = max, letter = letter, password = password };

            }


            return policyAndPasswords;
        }
        public struct PolicyAndPassword
        {
            public int min, max;
            public char letter;
            public string password;
        }
    }
}
