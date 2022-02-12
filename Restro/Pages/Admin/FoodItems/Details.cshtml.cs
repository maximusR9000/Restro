using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restro.Models;
using Restro.Services;

namespace Restro.Pages.Admin.FoodItems
{
    [Authorize(Roles = "Admin")]
    public class DetailsModel : PageModel
    {
        private readonly IFoodItemRepo _foodItemRepo;

        public DetailsModel(IFoodItemRepo foodItemRepo)
        {
            this._foodItemRepo = foodItemRepo;
        }

        public FoodItem foodItem { get; set; }

        [TempData]
        public string Message { get; set; }

        public IActionResult OnGet(int id)
        {
            try
            {
                foodItem = this._foodItemRepo.GetFoodItemById(id);

                if (foodItem == null)
                    return RedirectToPage("/NotFound");
            }
            catch (Exception e)
            {
                if (foodItem == null)
                    return RedirectToPage("/NotFound");
            }
            return Page();
        }
    }
}
