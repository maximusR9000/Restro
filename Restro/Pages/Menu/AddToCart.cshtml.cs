using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restro.Services;
using Restro.Models;
using Microsoft.AspNetCore.Authorization;

namespace Restro.Pages.Menu
{
    [Authorize]
    public class AddToCartModel : PageModel
    {
        private readonly ICartService cartService;
        private readonly IFoodItemRepo foodItemRepo;

        [BindProperty]
        public MyCart Cart { get; set; }

        public AddToCartModel(ICartService cartService, IFoodItemRepo foodItemRepo) 
        { 
            this.cartService = cartService;
            this.foodItemRepo = foodItemRepo;
        }
        public IActionResult OnGet(int id)
        {
            Cart = new MyCart();
            var foodItem = this.foodItemRepo.GetFoodItemById(id);

            if (cartService.isFoodItemExists(foodItem))
            {
                Cart = cartService.GetCartItem(foodItem);
                Cart.ItemQuantity++;
                cartService.UpdateItem(Cart);
                TempData["Message"] = "Added To Cart";
            }
            else
            {
                Cart.FoodId = id;
                Cart.ItemQuantity = 1;

                this.cartService.AddItemToCart(Cart);
                TempData["Message"] = "Added To Cart";
            }

            return RedirectToPage("/Menu");
            
        }
    }
}
