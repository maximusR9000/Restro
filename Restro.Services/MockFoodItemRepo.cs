using Restro.Models;

namespace Restro.Services
{
    public class MockFoodItemRepo
    {
        public List<FoodItem> FoodItems { get; set; }

        public MockFoodItemRepo()
        {
            FoodItems = new List<FoodItem>()
            {
                new FoodItem()
                {
                    Id = 1,
                    FoodItemName = "Dish 1",
                    FoodItemDescription = "Dish 2",
                    ImageUrl = "dish-1.png",
                    CategoryId = 1,

                },
                new FoodItem()
                {
                    Id = 2,
                    FoodItemName = "Dish 2",
                    FoodItemDescription = "Dish 2",
                    ImageUrl = "dish-2.png",
                    CategoryId = 1,

                },
                new FoodItem()
                {
                    Id = 3,
                    FoodItemName = "Dish 2",
                    FoodItemDescription = "Dish 2",
                    ImageUrl = "dish-2.png",
                    CategoryId = 2,

                }             

            };
        }



        public FoodItem AddFoodItem(FoodItem foodItem)
        {
            foodItem.Id = FoodItems.Max(i => i.Id) + 1;
            FoodItems.Add(foodItem);
            
            return foodItem;
        }

        public FoodItem GetFoodItemById(int id)
        {
            var foodItem = FoodItems.SingleOrDefault(i => i.Id == id);
            return foodItem;

        }

        public IEnumerable<FoodItem> GetFoodItems()
        {
            return FoodItems;
        }

        public FoodItem RemoveFoodItem(int id)
        {
            var foodItem = FoodItems.SingleOrDefault(i => i.Id == id);
            if (foodItem != null)
            {
                FoodItems.Remove(foodItem);
            }
            return foodItem;
        }

        public FoodItem UpdateFoodItem(FoodItem updatedFoodItem)
        {
            var foodItem = FoodItems.SingleOrDefault(i => i.Id == updatedFoodItem.Id);
            if (foodItem != null)
            {
                foodItem.Category = updatedFoodItem.Category;
                foodItem.CategoryId = updatedFoodItem.CategoryId;
                foodItem.FoodItemName = updatedFoodItem.FoodItemName;
                foodItem.FoodItemDescription = updatedFoodItem.FoodItemDescription;
            }
            return foodItem;
        }


        public List<FoodItem> GetFoodItemsByCategory(int id)
        {
            var foodItems = FoodItems.Where(m => m.CategoryId == id).ToList();
            return foodItems;
        }
    }
}
