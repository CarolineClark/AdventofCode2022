using System.Collections.Generic;
using System.Linq;

namespace DotnetStarter.Logic
{
    public class HelloWorld
    {
        public static string Hello() => "World!";

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
            var result = splitRucksackIntoKindsOfItemsByCompartment(input);
            return Enumerable.Intersect<string>(result.firstCompartment, result.secondCompartment).Single();
        }

        public static Rucksack splitRucksackIntoKindsOfItemsByCompartment(string input)
        {
            var compartmentLength = input.Length/2;
            var compartment1 = input.Substring(0, compartmentLength);
            var compartment2 = input.Substring(compartmentLength);
            return new Rucksack(splitCompartmentIntoKindsOfItems(compartment1), splitCompartmentIntoKindsOfItems(compartment2));
        }

        public static ISet<string> splitCompartmentIntoKindsOfItems(string input)
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
        }

        public static int priority_for_character(string character)
        {
            return "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(character) + 1;
        }
    }
}