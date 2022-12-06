using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Xunit;

namespace DotnetStarter.Logic.Tests
{
    
    public class AdventOfCode3Test
    {

        [Fact]
        public void AcceptanceTest2()
        {
            Assert.Equal(2716, AdventOfCode3.sumOfPriorityOfBadges(ReadFile()));
        }
        
        [Fact]
        public void test_sumOfBadges()
        {
            var bothGroups = @"vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw";
            Assert.Equal(70, AdventOfCode3.sumOfPriorityOfBadges(bothGroups));
        }

        [Fact]
        public void test_BadgeOfGroup()
        {
            var group = @"vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg";
            var expectedBadge = "r";
            Assert.Equal(expectedBadge, AdventOfCode3.badgeOfGroup(group));
        }
        
        [Fact]
        public void test_BadgeOfGroup2()
        {
            var group = @"vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg".Split("\n");
            var expectedBadge = "r";
            Assert.Equal(expectedBadge, AdventOfCode3.badgeOfGroup(group));
        }

        [Fact]
        public void AcceptanceTest1()
        {
            Assert.Equal(7967, AdventOfCode3.sumOfPriorityOfCommonItemsInRucksacks(ReadFile()));
        }
        
        public string ReadFile()
        {
            string contents = File.ReadAllText(@"../../../caroline.txt");
            return contents;
        }
        
        [Fact]
        public void AcceptanceTest()
        {
            var input = @"vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw";
            
            Assert.Equal(157, AdventOfCode3.sumOfPriorityOfCommonItemsInRucksacks(input));
        }

        [Theory]
        [InlineData("a", 1)]
        [InlineData("z", 26)]
        [InlineData("A", 27)]
        [InlineData("Z", 52)]
        public void test_priority_for_character(string character, int priority)
        {
            Assert.Equal(priority, AdventOfCode3.priority_for_character(character));
        }


        [Fact]
        public void CommonItemInCompartmentsTest1()
        {
            var input = @"vJrwpWtwJgWrhcsFMMfFFhFp";
            Assert.Equal("p", AdventOfCode3.commonItemInCompartments(input));
        }
        
        [Fact]
        public void CommonItemInCompartmentsTest2()
        {
            var input = @"jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL";
            Assert.Equal("L", AdventOfCode3.commonItemInCompartments(input));
        }

        [Fact]
        public void test_splitsRucksackIntoKindsOfItemsByCompartment()
        {
            var input = "abcDEF";
            var result = AdventOfCode3.Rucksack.fromString(input);
            Assert.Equal(result.firstCompartment, new HashSet<string>() { "a", "b", "c"});
            Assert.Equal(result.secondCompartment, new HashSet<string>() { "D", "E", "F"});
        }
        
        [Fact]
        public void test_splitsRucksackIntoKindsOfItemsByCompartment2()
        {
            var input = "DEFabc";
            var result = AdventOfCode3.Rucksack.fromString(input);
            Assert.Equal(result.firstCompartment, new HashSet<string>() { "D", "E", "F"});
            Assert.Equal(result.secondCompartment, new HashSet<string>() { "a", "b", "c"});
        }

        [Fact]
        public void test_splitsCompartmentIntoKindsOfItems()
        {
            var input = "DEFabc";
            var result = AdventOfCode3.kindsOfItems(input);
            Assert.Equal(result, new HashSet<string>() { "D", "E", "F", "a", "b", "c"});
        }
        
        [Fact]
        public void test_splitsCompartmentIntoKindsOfItems2()
        {
            var input = "DEFabcct";
            var result = AdventOfCode3.kindsOfItems(input);
            Assert.Equal(result, new HashSet<string>() { "D", "E", "F", "a", "b", "c", "t"});
        }


        [Fact]
        public void xunit_does_proper_collection_assertion()
        {
            var set1 = new HashSet<string>(new string[] {"1", "2"});
            var set2 = new SortedSet<string>(new string[] {"2", "1"});
            Assert.Equal(set1, set2);
        }
        
    }
}