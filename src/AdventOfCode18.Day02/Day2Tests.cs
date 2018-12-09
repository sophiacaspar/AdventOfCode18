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

        [Fact]
        public void Day2_part2()
        {
            var boxIDs = _day2.ReadFile();
            var differsWithOne = _day2.GetWordsThatDiffersOneLetter(boxIDs);
            string similarLetters = _day2.GetSimilarLettersFromWordsThatDiffersWithOne(differsWithOne);
            Assert.Equal("efmyhuckqldtwjyvisipargno", similarLetters);
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

        [Fact]
        public void Should_find_words_with_one_letters_difference()
        {
            var boxIDs = new List<string>(new string[]
                {"abcde", "fghij", "klmno", "pqrst","fguij","axcye","wvxyz"});
            var expectedDifferences = new List<string>(new string[]
                {"fghij", "fguij"});
            List<string> differsWithOne =  _day2.GetWordsThatDiffersOneLetter(boxIDs);
            Assert.Equal(expectedDifferences, differsWithOne);
        }

        [Fact]
        public void Should_find_words_that_differs_with_one_letter()
        {
            var differsWithOne = _day2.BoxIDsDiffersWithOne("fghij", "fguij");
            var differsWithMore = _day2.BoxIDsDiffersWithOne("abcde", "axcye");
            Assert.True(differsWithOne);
            Assert.False(differsWithMore);
        }

        [Fact]
        public void Should_find_similar_letters_from_words_that_differs_with_one()
        {
            var boxIDs = new List<string>(new string[]
                {"abcde", "fghij", "klmno", "pqrst","fguij","axcye","wvxyz"});
            var expectedSimilarities = "fgij";
            List<string> differsWithOne = _day2.GetWordsThatDiffersOneLetter(boxIDs);
            string similarLetters = _day2.GetSimilarLettersFromWordsThatDiffersWithOne(differsWithOne);
            Assert.Equal(expectedSimilarities, similarLetters);
        }
    }
}
