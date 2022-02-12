
namespace Restro.Models
{
    public class MyCart
    {
        public int Id { get; set; }
        public FoodItem Food { get; set; }
        public int FoodId { get; set; }
        public int ItemQuantity { get; set; }
    }
}
