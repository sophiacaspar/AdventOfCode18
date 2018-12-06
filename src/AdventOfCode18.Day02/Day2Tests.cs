using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Xunit;

namespace AdventOfCode18.Day02
{
    public class Day2Tests
    {
        private Day2 _day2;
        public Day2Tests()
        {
            _day2 = new Day2();
        }

        [Fact]
        public void Day2_part1()
        {
            var boxIDs = _day2.ReadFile();
            _day2.CountTotalLetterOccurenceForBoxId(boxIDs);
            int checkSum = _day2.GetCheckSum();
            Assert.Equal(7808, checkSum);
        }

        [Theory]
        [InlineData("abcdef", 0, 0)]
        [InlineData("bababc", 1, 1)]
        [InlineData("abbcde", 1, 0)]
        [InlineData("abcccd", 0, 1)]
        [InlineData("aabcdd", 1, 0)]
        [InlineData("abcdeed", 1, 0)]
        [InlineData("ababab", 0, 1)]
        public void Should_count_boxIDs_with_exact_two_or_three_same_letter_occurences(string boxId, int expectedTwo, int expectedThree)
        {
            _day2.CountLetterOccurenceInBoxID(boxId);
            int numberOfBoxIDsWith2LetterOccurences = _day2.TwoOccurenceCount;
            int numberOfBoxIDsWith3LetterOccurences = _day2.ThreeOccurenceCount;
            Assert.Equal(expectedTwo, numberOfBoxIDsWith2LetterOccurences);
            Assert.Equal(expectedThree, numberOfBoxIDsWith3LetterOccurences);
        }

        [Fact]
        public void Should_calculate_checksum()
        {
            var boxIDs = new List<string>(new string[]
                {"abcdef", "bababc", "abbcde", "abcccd", "aabcdd", "abcdeed", "ababab"});
            _day2.CountTotalLetterOccurenceForBoxId(boxIDs);
            int checkSum = _day2.GetCheckSum();
            Assert.Equal(12, checkSum);
        }
    }
}
