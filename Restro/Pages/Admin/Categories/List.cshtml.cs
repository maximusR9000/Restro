using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restro.Models;
using Restro.Services;

namespace Restro.Pages.Admin.Categories
{
    [Authorize(Roles = "Admin")]
    public class ListModel : PageModel
    {
        private readonly ICategoryRepo _categoryRepo;
        public ListModel(ICategoryRepo categoryRepo)
        {
            this._categoryRepo = categoryRepo;
        }
        public List<Category> Categories { get; set; }

        [BindProperty]
        public int Number { get; set; }

        public void OnGet()
        {
            Categories = this._categoryRepo.GetAllCategories();
        }

    }
}

