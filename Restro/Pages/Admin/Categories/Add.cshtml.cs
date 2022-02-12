using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restro.Models;
using Restro.Services;

namespace Restro.Pages.Admin.Categories
{
    [Authorize(Roles = "Admin")]
    public class AddModel : PageModel
    {

        private readonly ICategoryRepo _categoryRepo;

        public AddModel(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        [BindProperty]
        public Category category { get; set; }

        public List<Category> Categories { get; set; }
        public IActionResult OnGet(int? id)
        {
            Categories = this._categoryRepo.GetAllCategories();

            if (id.HasValue)
            {
                category = this._categoryRepo.GetCategoryById((int)id);
            }
            else
            {
                category = new Category();
            }

            if (category == null)
            {
                return RedirectToPage("/NotFound");
            }


            return Page();
        }

        public IActionResult OnPost()
        {
            if (category.Id > 0)
            {
                this._categoryRepo.UpdateCategory(category);
                TempData["Message"] = "Data Updated Successfully";
            }
            else
            {
                this._categoryRepo.AddCategory(category);
                TempData["Message"] = "Data Added Successfully";
            }

            return RedirectToPage("/Admin/Categories/Details", new { id = category.Id });
        }
    }
}
