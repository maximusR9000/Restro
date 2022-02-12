using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restro.Models;
using Restro.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Restro.Pages.Admin.FoodItems
{
    [Authorize(Roles = "Admin")]
    public class AddModel : PageModel
    {
        private readonly IFoodItemRepo _foodItemRepo;
        private readonly ICategoryRepo _categoryRepo;
        private readonly IHostEnvironment hostEnvironment;


        public AddModel(IFoodItemRepo foodItemRepo, IHostEnvironment environment, ICategoryRepo categoryRepo)
        {
            this._foodItemRepo = foodItemRepo;
            this.hostEnvironment = environment;    
            this._categoryRepo = categoryRepo;
        }

        
        public List<FoodItem> FoodItems { get; set; }
        public List<Category> Categories { get; set; }

        [BindProperty]
        public FoodItem foodItem { get; set; }

        [BindProperty]
        public int Number { get; set; }
        
        [BindProperty]
        public IFormFile ImageUrl { get; set; }

        public string FileName { get; set; }
        
        public IActionResult OnGet(int? id)
        {
            Categories = this._categoryRepo.GetAllCategories();
            if (id.HasValue)
            {
                FoodItems = this._foodItemRepo.GetFoodItems();
                foodItem = this._foodItemRepo.GetFoodItemById((int)id);
            }
            else
            {
                foodItem = new FoodItem();
            }

            if (foodItem == null)
            {
                return RedirectToPage("/NotFound");
            }


            return Page();
        }

        public IActionResult OnPost()
        {
            if (ImageUrl != null)
            {
                FileName = ProcessFileUpload();
            }
            else
            {
                FileName = "dish-1.png"; //Default Image
            }

            foodItem.ImageUrl = FileName;
                
            if (foodItem.Id > 0)
            {
                this._foodItemRepo.UpdateFoodItem(foodItem);
                TempData["Message"] = "Data Updated Successfully";
            }
            else
            {
                this._foodItemRepo.AddFoodItem(foodItem);
                TempData["Message"] = "Data Added Successfully";
            }

            return RedirectToPage("/Admin/FoodItems/List", new { id = foodItem.Id });
            
        }

        private string ProcessFileUpload()
        {
            string fileName = String.Empty;
            if (ImageUrl != null)
            {
                string folderPath = Path.Combine(this.hostEnvironment.ContentRootPath, "wwwroot", "images");
                fileName = Guid.NewGuid().ToString() + "_" + ImageUrl.FileName;
                string filePath = Path.Combine(folderPath, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    ImageUrl.CopyTo(fileStream);
                }
            }
            return fileName;
        }
    }
}
