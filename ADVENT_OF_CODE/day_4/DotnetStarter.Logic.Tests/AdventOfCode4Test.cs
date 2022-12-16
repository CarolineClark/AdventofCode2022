using System;
using System.IO;
using System.Linq;
using Xunit;

namespace DotnetStarter.Logic.Tests
{
    public class HelloWorldTest
    {
        [Fact]
        public void test_ParseRange()
        {
            Assert.Equal(ParseRange("3-5"), new Range { fromInclusive = 3, toInclusive = 5});
        }

        [Fact]
        public void test_Acceptance()
        {
            String s = @"2-4,6-8
2-3,4-5
5-7,7-9
2-8,3-7
6-6,4-6
2-6,4-8";
            var result = numberOfPairsWithOneRangeIncludedInTheOther(s);
            Assert.Equal(2, result);
        }

        [Fact]
        public void caroline_is_a_cutie()
        {
            var input = File.ReadAllText("../../../caroline.txt");
            Assert.Equal(569, numberOfPairsWithOneRangeIncludedInTheOther(input));

            Assert.Equal(936, numberOfPairsWithOverlap(input));
        }

        private int numberOfPairsWithOverlap(string input)
        {
            return input
                .Split("\n")
                .Select(ParsePairOfRanges)
                .Count(DoPairsOverlap);
        }

        private int numberOfPairsWithOneRangeIncludedInTheOther(string s)
        {
            return s
                .Split("\n")
                .Select(ParsePairOfRanges)
                .Count(DoPairsIntersect);
        }

        [Fact]
        public void test_ParsePairOfRanges()
        {
            Assert.Equal(ParsePairOfRanges("1-3,4-6"), (new Range{fromInclusive = 1, toInclusive = 3}, new Range{fromInclusive = 4, toInclusive = 6}));   
        }

        [Theory]
        [InlineData("1-3,4-5", false)]
        [InlineData("1-9,4-5", true)]
        [InlineData("1-3,3-3", true)]
        [InlineData("1-1,1-5", true)]
        [InlineData("1-5,1-5", true)]
        public void test_IntersectingPairs(string line, bool intersects)
        {
            Assert.Equal(intersects, DoPairsIntersect(ParsePairOfRanges(line)));
        }

        [Theory]
        [InlineData("1-3,4-5", false)]
        [InlineData("1-9,4-5", true)]
        [InlineData("1-3,3-3", true)]
        [InlineData("1-1,1-5", true)]
        [InlineData("1-5,1-5", true)]
        [InlineData("1-5,3-9", true)]
        [InlineData("3-5,1-4", true)]
        [InlineData("1-5,5-6", true)]
        [InlineData("3-5,1-3", true)]
        public void test_OverlappingPairs(string line, bool overlaps)
        {
            Assert.Equal(overlaps, DoPairsOverlap(ParsePairOfRanges(line)));
        }

        private bool DoPairsOverlap((Range, Range) parsePairOfRanges)
        {
            return
                DoesRightRangeStartInsideLeftRange(parsePairOfRanges.Item1, parsePairOfRanges.Item2) ||
                DoesRightRangeStartInsideLeftRange(parsePairOfRanges.Item2, parsePairOfRanges.Item1);
        }

        private bool DoesRightRangeStartInsideLeftRange(Range item1, Range item2)
        {
            return item2.fromInclusive >= item1.fromInclusive && item2.fromInclusive <= item1.toInclusive;
        }

        private bool DoPairsIntersect((Range r1, Range r2) parsePairOfRanges)
        {
            return DoesLeftRangeContainRight(parsePairOfRanges.r1, parsePairOfRanges.r2) || DoesLeftRangeContainRight(parsePairOfRanges.r2, parsePairOfRanges.r1);
        }

        private bool DoesLeftRangeContainRight(Range r1, Range r2)
        {
            return r1.fromInclusive <= r2.fromInclusive && r1.toInclusive >= r2.toInclusive;
        }


        private (Range, Range) ParsePairOfRanges(string s)
        {
            var ranges = s.Split(",").Select(s => ParseRange(s)).ToList();
            return (ranges[0], ranges[1]);
        }

        private Range ParseRange(string rangeInput)
        {
            var strings = rangeInput.Split("-");
            return new Range{fromInclusive = Int32.Parse(strings[0]), toInclusive = Int32.Parse(strings[1])};
        }
    }

    public struct Range
    {
        public int fromInclusive { get; set; }
        public int toInclusive { get; set; }
    }
}