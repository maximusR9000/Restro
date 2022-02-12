using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Restro.Models;
using Restro.Services;

namespace Restro.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly IUserAuthenticationService _userAuthenticationService;

        [BindProperty]
        public string ReturnUrl { get; set; } = "/Index";

        [BindProperty]
        public User User { get; set; }
        public LoginModel(IUserAuthenticationService authenticationService)
        {
            this._userAuthenticationService = authenticationService;
        }
        public void OnGet(string ReturnUrl)
        {
            this.ReturnUrl = ReturnUrl;
        }

        public async Task<IActionResult> OnPost()
        {
            var user = _userAuthenticationService.GetUser(User.Email, User.Password);
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid Username or Password");
                return Page();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.Id)),
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var props = new AuthenticationProperties();

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props);

            if (this.ReturnUrl == null)
                return RedirectToPage("/Index");
            
            return RedirectToPage(this.ReturnUrl);
        }
    }
}
