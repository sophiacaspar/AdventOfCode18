using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Xunit;

namespace AdventOfCode18.Day01
{
    public class Day1Tests
    {
        private Day1 _day1;
        public Day1Tests()
        {
            _day1 = new Day1();
        }

        [Fact]
        public void Day1_part1()
        {
            var frequencyChanges = _day1.ReadFile();
            _day1.UpdateFrequencyWithChanges(frequencyChanges);
            var resultFrequency = _day1.GetCurrentFrequency();
            Assert.Equal(510, resultFrequency);

        }

        [Fact]
        public void Day1_part2()
        {
            var frequencyChanges = _day1.ReadFile();
            var currentFrequencyList = _day1.GetCurrentFrequenciesWithDuplicates(frequencyChanges);
            int firstDuplicatedFrequency = _day1.GetFirstDuplicate(currentFrequencyList);

            Assert.Equal(69074, firstDuplicatedFrequency);
        }

        [Theory]
        [InlineData("+1", 1)]
        [InlineData("+2", 2)]
        [InlineData("+4", 4)]
        public void Frequency_should_increase_with_change(string frequencyChange, int expectedResultFrequency)
        {
            _day1.ChangeFrequency(frequencyChange);
            var newFrequency = _day1.GetCurrentFrequency();

            Assert.Equal(expectedResultFrequency, newFrequency);
        }

        [Theory]
        [InlineData("-1", -1)]
        [InlineData("-2", -2)]
        [InlineData("-4", -4)]
        public void Frequency_should_decrease_with_change(string frequencyChange, int expectedResultFrequency)
        {
            _day1.ChangeFrequency(frequencyChange);
            var newFrequency = _day1.GetCurrentFrequency();

            Assert.Equal(expectedResultFrequency, newFrequency);
        }

        [Fact]
        public void Update_frequency_with_multiple_changes()
        {
            var changes = new List<string>(new string[] { "+1", "-2", "+3", "+1" });
            _day1.UpdateFrequencyWithChanges(changes);
            var resultFrequency = _day1.GetCurrentFrequency();
            Assert.Equal(3, resultFrequency);
        }

        [Fact]
        public void Should_find_duplicates_in_list()
        {
            var inputList = new List<int>(new int[] { 1, 10, -5, 7, 10, 1});
            int duplicate = _day1.GetFirstDuplicate(inputList);

            Assert.Equal(10, duplicate);
        }

        [Fact]
        public void Should_check_if_duplicates_exists()
        {
            var inputList = new List<int>(new int[] { 1, 10, -5, 7, 10, 1 });
            var duplicate = _day1.CheckIfDuplicateExists(inputList);

            Assert.True(duplicate);
        }

        [Fact]
        public void Should_add_current_frequencies_in_list()
        {
            var changes = new List<string>(new string[] {"+1", "+1", "+1", "-2"});
            var expectedFrequencies = new List<int>(new int[] { 1, 2, 3, 1 });
            _day1.AddCurrentFrequencyInList(changes);
            var currentFrequencyList = _day1.GetCurrentFrequencies();
            Assert.Equal(expectedFrequencies, currentFrequencyList);   
        }

        [Fact]
        public void Should_find_first_duplicated_frequency_with_loop()
        {
            //var changes = new List<string>(new string[] { "+3", "+3", "+4", "-2", "-4" });
            //var changes = new List<string>(new string[] { "-6", "+3", "+8", "+5", "-6" });
            var changes = new List<string>(new string[] { "+7", "+7", "-2", "-7", "-4" });
            List<int> currentFrequencyList = _day1.GetCurrentFrequenciesWithDuplicates(changes);
            int duplicate = _day1.GetFirstDuplicate(currentFrequencyList);

            Assert.Equal(14, duplicate);
        }
    }
}

