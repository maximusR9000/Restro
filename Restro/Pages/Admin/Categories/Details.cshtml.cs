using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Restro.Models;
using Restro.Services;


namespace Restro.Pages.Admin.Categories
{
    [Authorize(Roles = "Admin")]
    public class DetailsModel : PageModel
    {
        private readonly ICategoryRepo _categoryRepo;

        public DetailsModel(ICategoryRepo categoryRepo)
        {
            this._categoryRepo = categoryRepo;
        }

        public Category category { get; set; }

        [TempData]
        public string Message { get; set; }

        public IActionResult OnGet(int id)
        {
            try
            {
                category = this._categoryRepo.GetCategoryById(id);

                if (category == null)
                    return RedirectToPage("/NotFound");
            }
            catch (Exception e)
            {
                if (category == null)
                    return RedirectToPage("/NotFound");
            }
            return Page();
        }
    }
}
