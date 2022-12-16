using System.Collections.Generic;
using System.IO;
using Xunit;

namespace DotnetStarter.Logic.Tests
{
    public class HelloWorldTest
    {
        [Fact]
        public void AcceptanceTest()
        {
            string contents = File.ReadAllText("../../../caroline.txt");
            Assert.Equal(70764, HelloWorld.CaloriesInBiggest3FoodBags(contents));
        }

        [Fact]
        public void ExampleInputFinalTest2()
        {
            var exampleInput = @"1000
2000
3000

4000

5000
6000

7000
8000
9000

10000";
            int mostCalories = HelloWorld.CaloriesInBiggest3FoodBags(exampleInput);
            Assert.Equal(45000, mostCalories);
        }

        [Fact]
        public void ExampleInputFinalTest()
        {
            var exampleInput = @"1000
2000
3000

4000

5000
6000

7000
8000
9000

10000";
            int mostCalories = HelloWorld.CaloriesInBiggestFoodBag(exampleInput);
            Assert.Equal(24000, mostCalories);
        }

        [Fact]
        public void ParsingStringIntoFoodBags()
        {
            var exampleInput = @"1000
2000
3000

4000";
            List<FoodBag> foodBags = HelloWorld.ToFoodBags(exampleInput);

            var foodBag1 = new FoodBag(new List<int>() {1000,2000,3000});
            var foodBag2 = new FoodBag(new List<int>() {4000});

            Assert.Equal(foodBag1.calories, foodBags[0].calories);
            Assert.Equal(foodBag2.calories, foodBags[1].calories);
        }
    }
}