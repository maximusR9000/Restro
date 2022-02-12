using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restro.Models;
using Restro.Services;

namespace Restro.Pages.Admin.Categories
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly ICategoryRepo _categoryRepo;
        public DeleteModel(ICategoryRepo categoryRepo)
        {
            this._categoryRepo = categoryRepo;
        }

        public Category category { get; set; }
        public IActionResult OnGet(int id)
        {
            category = this._categoryRepo.GetCategoryById(id);

            if (category == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();

        }

        public IActionResult OnPost(int id)
        {
            category = this._categoryRepo.RemoveCategory(id);

            if (category == null)
            {
                return RedirectToPage("/NotFound");
            }

            return RedirectToPage("/Admin/Categories/List");
        }
    }
}
