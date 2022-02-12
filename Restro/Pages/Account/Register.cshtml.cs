using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restro.Models;
using Restro.Services;
using System.Security.Claims;

namespace Restro.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private IUserAuthenticationService _userAuthenticationService;

        public RegisterModel(IUserAuthenticationService userAuthenticationService)
        {
            this._userAuthenticationService = userAuthenticationService;
        }

        [BindProperty]
        public string RememberPassword { get; set; }
        
        [BindProperty]
        public User registerUser { get; set; }
        
        
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {

            if (!RememberPassword.Equals(registerUser.Password))
                ModelState.AddModelError("", "Please check the password again");
            else
            {
                var result = this._userAuthenticationService.AddUser(registerUser.Email, registerUser.Password);

                if(result == true)
                {
                    var user = _userAuthenticationService.GetUser(registerUser.Email, registerUser.Password);
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
                    
                    return RedirectToPage("/Index");
                }
                
            }
            return Page();
        }
    }
}
