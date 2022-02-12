using System.ComponentModel.DataAnnotations;

namespace Restro.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Category Name can't be blank")]
        [Display(Name ="Category Name")]
        public string CategoryName { get; set; }

        [Display(Name ="Short Description")]
        [MaxLength(255, ErrorMessage = "Description should not exceed 255 Characters")]
        public string ShortDescription { get; set; }

        public List<FoodItem> FoodItems { get; set; } = new List<FoodItem>();
    }
}