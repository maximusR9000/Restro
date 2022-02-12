using System;
using Microsoft.EntityFrameworkCore;
using Restro.Models;

namespace Restro.Services
{
    public class CategoryRepoService : ICategoryRepo
    {
        private readonly ProjectDBContext _db;
        public CategoryRepoService(ProjectDBContext dbContext)
        {
            this._db = dbContext;
        }

        public List<Category> GetAllCategories()
        {
            return this._db.Categories.ToList();
        }

        public Category GetCategoryByFoodItemId(int id)
        {
            return this._db.FoodItems.SingleOrDefault(f => f.CategoryId == id).Category;
        }

        public List<FoodItem> GetFoodItems()
        {
            return this._db.FoodItems.ToList();
        }

        public List<FoodItem> GetFoodItemsByCategory(int id)
        {
            var foodItems = this._db.FoodItems.Where(f => f.CategoryId == id).ToList();
            return foodItems;
        }

        public Category GetCategoryById(int id)
        {
            return _db.Categories.SingleOrDefault(c => c.Id == id);
        }

        public Category AddCategory(Category newCategory)
        {
            this._db.Add(newCategory);
            this._db.SaveChanges();

            return newCategory;
        }

        public Category UpdateCategory(Category updatedCategory)
        {
            this._db.Categories.Update(updatedCategory);
            this._db.SaveChanges();

            return updatedCategory;
        }

        public Category RemoveCategory(int id)
        {
            var category = this.GetCategoryById(id);
            if (category != null)
            {
                this._db.Categories.Remove(category);
                this._db.SaveChanges();
            }

            return category;
        }
    }
}
