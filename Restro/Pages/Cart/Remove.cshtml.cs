using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restro.Models;
using Restro.Services;

namespace Restro.Pages.Cart
{
    [Authorize]
    public class RemoveModel : PageModel
    {
        private readonly ICartService cartService;
        private readonly IFoodItemRepo foodItemRepo;
        public MyCart Cart { get; set; }

        public RemoveModel(ICartService cartService, IFoodItemRepo foodItemRepo)
        {
            this.cartService = cartService;
            this.foodItemRepo = foodItemRepo;
        }
        public IActionResult OnGet(int id)
        {
            
            TempData["Message"] = "Item Removed";
            cartService.RemoveItemFromCart(id);
            

            return RedirectToPage("/Cart/Index");

        }
    }
}
