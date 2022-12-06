using System;
using System.Collections.Generic;
using System.Linq;

namespace DotnetStarter.Logic
{
    public class AdventOfCode3
    {
        public static int sumOfPriorityOfCommonItemsInRucksacks(string input)
        {
            return input
                .Split("\n")
                .Select<string, string>(rucksack => commonItemInCompartments(rucksack))
                .Select<string, int>(commonItem => priority_for_character(commonItem))
                .Sum();
        }

        public static string commonItemInCompartments(string input)
        {
            var result = Rucksack.fromString(input);
            return Enumerable.Intersect<string>(result.firstCompartment, result.secondCompartment).Single();
        }

        public static ISet<string> kindsOfItems(string input)
        {
            return new HashSet<string>(input.Select(c => c.ToString()));
        }

        public struct Rucksack
        {
            public ISet<string> firstCompartment;
            public ISet<string> secondCompartment;

            public Rucksack(ISet<string> firstCompartment, ISet<string> secondCompartment)
            {
                this.firstCompartment = firstCompartment;
                this.secondCompartment = secondCompartment;
            }

            public static Rucksack fromString(string input)
            {
                var compartmentLength = input.Length/2;
                var compartment1 = input.Substring(0, compartmentLength);
                var compartment2 = input.Substring(compartmentLength);
                return new Rucksack(kindsOfItems(compartment1), kindsOfItems(compartment2));
            }
        }

        public static int priority_for_character(string character)
        {
            return "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(character) + 1;
        }

        public static int sumOfPriorityOfBadges(string readFile)
        {
            return readFile
                .Split("\n")
                .Chunk(3)
                .Select(groupOfElves => badgeOfGroup(groupOfElves))
                .Select(badge => priority_for_character(badge))
                .Sum();
        }

        public static string badgeOfGroup(string groupOfElves)
        {
            var lines = groupOfElves
                .Split("\n");
            return badgeOfGroup(lines);
        }

        public static string badgeOfGroup(IEnumerable<string> lines)
        {
            return lines
                .Select(elf => kindsOfItems(elf))
                .Aggregate((a, b) => a.Intersect(b).ToHashSet()).First();
        }
    }
}