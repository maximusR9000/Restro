using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restro.Models;
using Restro.Services;
using System.Security.Claims;

namespace Restro.Pages.OrderPage
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ICartService cartService;
        private readonly IOrderService orderService;

        public IndexModel(ICartService cartService, IOrderService orderService)
        {
            this.cartService = cartService;
            this.orderService = orderService;
        }

        [BindProperty]
        public List<Order> orderDetails { get; set; }
        public void OnGet()
        {
            cartService.ClearCart();
            orderDetails = orderService.GetOrdersByUser(int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value));
        }

    }
}
