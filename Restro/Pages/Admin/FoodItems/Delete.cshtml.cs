using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restro.Models;
using Restro.Services;

namespace Restro.Pages.Admin.FoodItems
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly IFoodItemRepo _foodItemRepo;
        public DeleteModel(IFoodItemRepo foodItemRepo)
        {
            this._foodItemRepo = foodItemRepo;
        }

        public FoodItem foodItem { get; set; }
        public IActionResult OnGet(int id)
        {
            foodItem = this._foodItemRepo.GetFoodItemById(id);

            if(foodItem == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();

        }

        public IActionResult OnPost(int id)
        {
            foodItem = this._foodItemRepo.RemoveFoodItem(id);

            if(foodItem == null)
            {
                return RedirectToPage("/NotFound");
            }

            return RedirectToPage("/Admin/FoodItems/List");
        }
    }
}
