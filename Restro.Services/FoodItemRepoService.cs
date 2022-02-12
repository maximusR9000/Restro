using System;
using Microsoft.EntityFrameworkCore;
using Restro.Models;

namespace Restro.Services
{
    public class FoodItemRepoService : IFoodItemRepo
    {
        private readonly ProjectDBContext _db;

        public FoodItemRepoService(ProjectDBContext dBContext)
        {
            this._db = dBContext;
        }


        public FoodItem GetFoodItemById(int id)
        {
            return this._db.FoodItems.SingleOrDefault(f => f.Id == id);
        }
        public Category GetCategoryByFoodItemId(int id)
        {
            return this._db.FoodItems.SingleOrDefault(f => f.Id == id).Category;
        }

        public List<FoodItem> GetFoodItems()
        {
            return this._db.FoodItems.ToList();
        }

        public List<FoodItem> GetFoodItemsByCategory(int id)
        {
            return this._db.FoodItems.Where(f => f.CategoryId == id).ToList();
        }
        public FoodItem AddFoodItem(FoodItem newFoodItem)
        {
            this._db.Add(newFoodItem);
            this._db.SaveChanges();

            return newFoodItem;
        }

        public FoodItem RemoveFoodItem(int id)
        {
            var foodItem = this.GetFoodItemById(id);
            if(foodItem != null)
            {
                this._db.FoodItems.Remove(foodItem);
                this._db.SaveChanges();
            }

            return foodItem;
        }

        public FoodItem UpdateFoodItem(FoodItem updatedFoodItem)
        {
            this._db.FoodItems.Update(updatedFoodItem);
            this._db.SaveChanges();

            return updatedFoodItem;
        }
    }
}
