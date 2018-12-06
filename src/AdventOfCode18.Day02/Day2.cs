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
    }
}
