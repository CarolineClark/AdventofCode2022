using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;

namespace DotnetStarter.Logic
{
    public class HelloWorld
    {
        public static string Hello() => "World!";

        public static int CaloriesInBiggest3FoodBags(string exampleInput)
        {
            var foodbags = ToFoodBags(exampleInput);
            var list = foodbags.Select(delegate(FoodBag f)
            {
                int sum = 0;
                foreach (var foodItem in f.calories)
                {
                    sum += foodItem;
                }

                return sum;
            }).OrderByDescending(o=>o).ToList();
            return list[0] +list[1]+list[2];
        }

        public static int CaloriesInBiggestFoodBag(string exampleInput)
        {
            var foodbags = ToFoodBags(exampleInput);
            return foodbags.Select(delegate(FoodBag f)
            {
                int sum = 0;
                foreach (var foodItem in f.calories)
                {
                    sum += foodItem;
                }

                return sum;
            }).Max();
        }

        public static List<FoodBag> ToFoodBags(string exampleInput)
        {
            var foodBags = new List<FoodBag>();
            var strings = exampleInput.Split("\n\n");
            for (int i = 0; i < strings.Length; i++)
            {
                var foodBag = strings[i].Split("\n");
                foodBags.Add(
                    new FoodBag(foodBag.ToList().Select(IntegerType.FromString).ToList())
                    );
            }

            return foodBags;
        }
    }
    
    public struct FoodBag
    {
        public List<int> calories;
        public FoodBag(List<int> calories)
        {
            this.calories = calories;
        }
    }
}