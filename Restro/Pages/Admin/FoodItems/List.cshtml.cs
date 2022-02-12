using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Restro.Services;
using Restro.Models;
using Microsoft.AspNetCore.Authorization;

namespace Restro.Pages.Admin.FoodItems
{
    [Authorize(Roles = "Admin")]
    public class ListModel : PageModel
    {
        private readonly ICategoryRepo _categoryRepo;
        public ListModel(ICategoryRepo categoryRepo)
        {
            this._categoryRepo = categoryRepo;
        }

       
        public Category currentCategory { get; set; }
        public List<Category> Categories { get; set; }
        public List<FoodItem> FoodItems { get; set; }   
        
        [BindProperty]
        public int Number { get; set; }
        
        public void OnGet()
        {
            Categories = this._categoryRepo.GetAllCategories();
            FoodItems = this._categoryRepo.GetFoodItemsByCategory(1);
            currentCategory = Categories[0];
        }

        public void OnPost()
        {
            Categories = this._categoryRepo.GetAllCategories();

            FoodItems = this._categoryRepo.GetFoodItemsByCategory(Number);
        }

    }
}
