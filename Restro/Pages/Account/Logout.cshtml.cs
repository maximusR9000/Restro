using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Restro.Models;
using Restro.Services;

namespace Restro.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private ICartService cartService;


        public LogoutModel(ICartService cartService)
        {
            this.cartService = cartService;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            cartService.ClearCart();
            return RedirectToPage("/Index");
        }
    }
}
