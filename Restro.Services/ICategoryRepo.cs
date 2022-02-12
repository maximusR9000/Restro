using System;
using Restro.Models;

namespace Restro.Services
{
    public interface ICategoryRepo
    {
        public List<Category> GetAllCategories();
        public List<FoodItem> GetFoodItems();
        public List<FoodItem> GetFoodItemsByCategory(int id);
        public Category GetCategoryByFoodItemId(int id);
        public Category GetCategoryById(int id);

        public Category AddCategory(Category newCategory);
        public Category UpdateCategory(Category updatedCategory);
        public Category RemoveCategory(int id);
    }
}
