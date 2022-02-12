using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using Restro.Services;
using Restro.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Restro.Pages.OrderPage
{
    [Authorize(Roles = "User")]
    public class PlaceOrderModel : PageModel
    {
        private readonly IOrderService orderService;
        private readonly ICartService cartService;
        private readonly IUserAuthenticationService userService;

        public PlaceOrderModel(IOrderService orderService, ICartService cartService, IUserAuthenticationService userService)
        {
            this.orderService = orderService;
            this.cartService = cartService;
            this.userService = userService;
        }


        //---------------------------------//
        [BindProperty]
        public Order Order { get; set; }




        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            List<MyCart> cart = this.cartService.GetCart();
            int userId = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);

            foreach (var cartItem in cart)
            {
                OrderDetails orderDetails = new OrderDetails();

                orderDetails.Qty = cartItem.ItemQuantity;
                orderDetails.UserId = userId;
                orderDetails.FoodItemId = cartItem.FoodId;

                orderService.AddOrderDetails(orderDetails);
            }

            Order.OrderDate = DateTime.Now;
            Order.TotalPrice = cartService.GetTotalAmount();
            Order.UserId = userId;

            this.orderService.AddOrder(Order);
            cartService.ClearCart();

            return RedirectToPage("/OrderPage/Index");
        }
    }
}
