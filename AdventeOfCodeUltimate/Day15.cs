using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeUltimate
{
    class Day15 : IAdventOfCode

    {
        //  int numTurns = 2020;
        int numTurns = 30000000;
        int[] puzzleInputSeedNumbers = { 0, 14, 6, 20, 1, 4 };
        Hashtable spokenNumbers = new Hashtable();

        public void DoTask()
        {
            Task1();
        }

        void Task1()
        {
            int[] seedNumbers = puzzleInputSeedNumbers;
            int turn = 1;

            for ( ; turn <= seedNumbers.Length; turn++)
            {
                SpeakNumber(seedNumbers[turn - 1], turn);
            }

            int prevSpoken = seedNumbers.Last();

            for (; turn <= numTurns; turn++)
            {
                int speak = GetTurnSinceLastSpoken(prevSpoken, turn);
                SpeakNumber(speak, turn);
                prevSpoken = speak;
            }

            Console.WriteLine(($"Last spoken on turn {turn - 1} was {prevSpoken}"));
        }

        int GetTurnSinceLastSpoken(int num, int currentTurn)
        {
            int[] turnsSpoken = (int[])spokenNumbers[num];

            if (turnsSpoken[0] == -1)
            {
                return 0;
            }

            int lastTurnSpoken = turnsSpoken[0];
            return currentTurn - 1 - lastTurnSpoken;
        }


        void SpeakNumber(int num, int currentTurn)
        {
            int[] turnsSpoken = (int[])spokenNumbers[num];

            if (turnsSpoken == null)
            {
                turnsSpoken = new int[2] { -1, currentTurn };
                spokenNumbers[num] = turnsSpoken;
            }
            else
            {
                turnsSpoken[0] = turnsSpoken[1];
                turnsSpoken[1] = currentTurn;
            }
        }


    }
}
