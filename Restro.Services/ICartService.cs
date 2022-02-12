using Restro.Models;

namespace Restro.Services
{
    public interface ICartService
    {
        MyCart AddItemToCart(MyCart newCart);
        MyCart RemoveItemFromCart(int id);
        MyCart UpdateItem(MyCart updatedCart);
        bool isFoodItemExists(FoodItem foodItem);
        MyCart GetCartItem(FoodItem foodItem);
        int GetCartItemsQuantity();
        List<MyCart> GetCart();
        decimal GetTotalAmount();
        void ClearCart();

    }
}
