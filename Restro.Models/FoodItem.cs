using System;
using System.ComponentModel.DataAnnotations;

namespace Restro.Models
{
    public class FoodItem
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Food Item Name")]
        public string FoodItemName { get; set; }

        [Required, Display(Name = "Food Item Description")]
        public string FoodItemDescription { get; set; }
        
        [Required(ErrorMessage = "Price can't be blank")]
        [Range(1, 1000)]
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        public Category Category { get; set; }

        [Required(ErrorMessage = "Category can't be blank")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public string ImageUrl { get; set; }

    }
}
