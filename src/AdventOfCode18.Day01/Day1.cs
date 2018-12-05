using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode18.Day01
{
    class Day1
    {
        private int _currentFrequency;
        private List<int> _currentFrequencies = new List<int>();
        private char[] _signs = { '+', '-' };
        public void ChangeFrequency(string frequencyChange)
        {
            var change = frequencyChange.Split(_signs);
            var sign = frequencyChange[0];
            int frequency = Int32.Parse(change[1]);
            if (sign == '+')
            {
                _currentFrequency += frequency;
            }
            else
            {
                _currentFrequency -= frequency;
            }
        }

        public int GetCurrentFrequency()
        {
            return _currentFrequency;
        }

        public void UpdateFrequencyWithChanges(List<string> changes)
        {
            foreach (var change in changes)
            {
                ChangeFrequency(change);
            }
        }

        public List<string> ReadFile()
        {
            var frequencyChanges = new List<string>();
            try
            {
                var path = @"C:\dev\repos\AdventOfCode18\src\AdventOfCode18.Day01\Day1.txt";
                var formatedTextLine = File.ReadAllText(path).Replace("\n", " ").Replace("\r", String.Empty);
                var txtLines = formatedTextLine.Split(' ');

                foreach (var txtLine in txtLines)
                {
                    frequencyChanges.Add(txtLine);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e);
            }
            return frequencyChanges;
        }

        public bool CheckIfDuplicateExists(List<int> frequencies)
        {
            var duplicateCount = frequencies.GroupBy(i => i).Where(g => g.Count() > 1).Select(g => g.Key);
            if (duplicateCount.Count() > 0)
            {
                return true;
            }
            return false;
        }

        public int GetFirstDuplicate(List<int> frequencies)
        {
            int duplicateIndex = frequencies.Count;
            for (int frequency = 0; frequency < frequencies.Count-1; frequency++)
            {
                for (int j = 0; j < frequencies.Count-1; j++)
                {
                    if (frequencies[frequency] == frequencies[j] && frequency != j && j < duplicateIndex && frequency < duplicateIndex)
                    {
                        duplicateIndex = j;
                    }
                }
            }
            return frequencies[duplicateIndex];
        }

        public void AddCurrentFrequencyInList(List<string> changes)
        {
            foreach (var change in changes)
            {
                ChangeFrequency(change);
                _currentFrequencies.Add(GetCurrentFrequency());
            }
        }

        public List<int> GetCurrentFrequencies()
        {
            return _currentFrequencies;
        }

        public List<int> GetCurrentFrequenciesWithDuplicates(List<string> changes)
        {
            AddCurrentFrequencyInList(changes);
            if (!CheckIfDuplicateExists(_currentFrequencies))
            {
                GetCurrentFrequenciesWithDuplicates(changes);
            }
            return _currentFrequencies;
        }
    }
}
