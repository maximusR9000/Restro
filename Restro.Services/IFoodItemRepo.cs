using System;
using Restro.Models;
using Restro.Services;

namespace Restro.Services
{
    public interface IFoodItemRepo
    {
        public List<FoodItem> GetFoodItems();
        public FoodItem GetFoodItemById(int id);
        public List<FoodItem> GetFoodItemsByCategory(int id);
        public Category GetCategoryByFoodItemId(int id);

        //CRUD Operations
        public FoodItem AddFoodItem(FoodItem newFoodItem);
        public FoodItem RemoveFoodItem(int id);
        public FoodItem UpdateFoodItem(FoodItem updatedFoodItem);
    }
}
