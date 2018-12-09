using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode18.Day02
{
    class Day2
    {
        private int _threeOccurenceCount;
        private int _twoOccurenceCount;
        public int TwoOccurenceCount
        {
            get { return _twoOccurenceCount; }
        }
        public int ThreeOccurenceCount
        {
            get { return _threeOccurenceCount; }
        }

        public void CountLetterOccurenceInBoxID(string boxId)
        {
            var findExactTwoOccurences = boxId.GroupBy(x => x).Where(g => g.Count() == 2).Select(g => g.Key);
            var findExactThreeOccurences = boxId.GroupBy(x => x).Where(g => g.Count() == 3).Select(g => g.Key);

            if (findExactTwoOccurences.Count() > 0)
            {
                _twoOccurenceCount++;
            }

            if (findExactThreeOccurences.Count() > 0)
            {
                _threeOccurenceCount++;
            }
        }

        public void CountTotalLetterOccurenceForBoxId(List<string> boxIDs)
        {
            foreach (var boxID in boxIDs)
            {
                CountLetterOccurenceInBoxID(boxID);
            }
        }

        public int GetCheckSum()
        {
            return _twoOccurenceCount * _threeOccurenceCount;
        }

        public List<string> ReadFile()
        {
            var boxIDs = new List<string>();
            try
            {
                var path = @"C:\dev\repos\AdventOfCode18\src\AdventOfCode18.Day02\Day2.txt";
                var txtLines = File.ReadLines(path);

                foreach (var txtLine in txtLines)
                {
                    boxIDs.Add(txtLine);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e);
            }
            return boxIDs;
        }

        public List<string> GetWordsThatDiffersOneLetter(List<string> boxIDs)
        {
            List<string> differsWithOne = new List<string>();
            foreach (var currentBoxID in boxIDs)
            {
                foreach (var boxID in boxIDs)
                {
                    if (BoxIDsDiffersWithOne(currentBoxID, boxID))
                    {
                        differsWithOne.Add(currentBoxID);
                    }
                }
            }

            return differsWithOne;
        }

        public bool BoxIDsDiffersWithOne(string currentBoxId, string boxId)
        {
            var differences = 0;
            if (currentBoxId == boxId) { return false; }
            for (int i = 0; i < currentBoxId.Length; i++)
            {
                if (currentBoxId[i] != boxId[i] && currentBoxId.Length == boxId.Length)
                {
                    differences++;
                }
            }

            if (differences == 1)
            {
                return true;
            }

            return false;
        }

        public string GetSimilarLettersFromWordsThatDiffersWithOne(List<string> differsWithOne)
        {
            var similarLetters = string.Empty;
            var firstWord = differsWithOne[0];
            var secondWord = differsWithOne[1];
            for (int i = 0; i < firstWord.Length; i++)
            {
                if (firstWord[i] == secondWord[i])
                {
                    similarLetters += firstWord[i];
                }
            }
            return similarLetters;
        }
    }
}
