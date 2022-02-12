using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restro.Services;
using Restro.Models;
using Microsoft.AspNetCore.Authorization;

namespace Restro.Pages
{
    [Authorize]
    public class OrderModel : PageModel
    {
        private readonly ICartService cartService;
        private readonly IFoodItemRepo foodItemRepo;

        [BindProperty]
        public List<MyCart> cartItems { get; set; }

        [BindProperty]
        public int totalItems { get; set; }
        
        [BindProperty]
        public decimal totalPrice { get; set; }

        [TempData]
        public string Message { get; set; }
        public OrderModel(ICartService cartService, IFoodItemRepo foodItemRepo)
        {
            this.cartService = cartService;
            this.foodItemRepo = foodItemRepo;
        }

        public FoodItem GetFoodItem(int id)
        {
            return this.foodItemRepo.GetFoodItemById(id);
        }
        
        public void OnGet()
        {
            cartItems = cartService.GetCart();
            totalItems = cartService.GetCartItemsQuantity();
            totalPrice = cartService.GetTotalAmount();
        }

        public void OnPost()
        {

        }
    }
}
