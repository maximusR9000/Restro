using NUnit.Framework;
using Restro.Models;
using Restro.Services;
using System.Collections.Generic;

namespace Restro.NUnitTest
{

    [TestFixture]
    public class Tests
    {
        private List<FoodItem> foodItems;
        private FoodItem foodItem;
        private MockFoodItemRepo foodRepo;

        [SetUp]
        public void Setup()
        {
            foodItems = new List<FoodItem>();
            foodItem = new FoodItem();
            foodRepo = new MockFoodItemRepo();

        }

        [Test]
        [TestCase(1)]
        public void TestMethod_GetFoodItemsByCategory(int id)
        {
            foodItems = foodRepo.GetFoodItemsByCategory(id);

            Assert.That(foodItems.Count, Is.EqualTo(2));
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        public void TestMethod_GetFoodItemById(int id)
        {
            foodItem = foodRepo.GetFoodItemById(id);
            Assert.IsNotNull(foodItem);
        }
    }
}