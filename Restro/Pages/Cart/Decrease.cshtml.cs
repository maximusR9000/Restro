using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restro.Models;
using Restro.Services;

namespace Restro.Pages.Cart
{
    [Authorize]
    public class DecreaseModel : PageModel
    {
        private readonly ICartService cartService;
        private readonly IFoodItemRepo foodItemRepo;
        public MyCart Cart { get; set; }

        public DecreaseModel(ICartService cartService, IFoodItemRepo foodItemRepo)
        {
            this.cartService = cartService;
            this.foodItemRepo = foodItemRepo;
        }
        public IActionResult OnGet(int id)
        {
            var foodItem = this.foodItemRepo.GetFoodItemById(id);
            Cart = cartService.GetCartItem(foodItem);

            if (cartService.isFoodItemExists(foodItem))
            {
                if(Cart.ItemQuantity == 1)
                {
                    TempData["Message"] = "Item Removed";
                    return RedirectToPage("/Cart/Remove", new { id = Cart.Id });
                }
                else
                {
                    Cart.ItemQuantity--;
                    cartService.UpdateItem(Cart);
                }
                
            }

            return RedirectToPage("/Cart/Index");

        }
    }
}
