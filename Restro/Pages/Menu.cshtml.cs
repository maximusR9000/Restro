using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restro.Models;
using Restro.Services;

namespace Restro.Pages
{
    [AllowAnonymous]
    public class MenuModel : PageModel
    {
        private readonly IFoodItemRepo _foodItemRepo;

        public List<FoodItem> FoodItems { get; set; }

        [TempData]
        public string Message { get; set; }
        public MenuModel(IFoodItemRepo foodItemRepo)
        {
            this._foodItemRepo = foodItemRepo;
        }
        public void OnGet()
        {
            FoodItems = this._foodItemRepo.GetFoodItems();
        }
    }
}
