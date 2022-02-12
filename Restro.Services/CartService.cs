using Microsoft.EntityFrameworkCore;
using Restro.Models;

namespace Restro.Services
{
    public class CartService : ICartService
    {

        private readonly ProjectDBContext _dbContext;
        private readonly IFoodItemRepo _foodItemRepo;

        public CartService(ProjectDBContext dBContext, IFoodItemRepo foodItemRepo)
        {
            this._dbContext = dBContext;
            this._foodItemRepo = foodItemRepo;
        }
        public MyCart AddItemToCart(MyCart newCart)
        {
            this._dbContext.MyCart.Add(newCart);
            this._dbContext.SaveChanges();

            return newCart;
        }

        public MyCart RemoveItemFromCart(int id)
        {
            var cart = this._dbContext.MyCart.SingleOrDefault(c => c.Id == id);
            if (cart != null)
            {
                this._dbContext.MyCart.Remove(cart);
                this._dbContext.SaveChanges();
            }

            return cart;
        }

        public MyCart UpdateItem(MyCart updatedCart)
        {
            this._dbContext.MyCart.Update(updatedCart);
            this._dbContext.SaveChanges();

            return updatedCart;
        }

        public bool isFoodItemExists(FoodItem foodItem)
        {
            var result = this._dbContext.MyCart.SingleOrDefault(f => f.Food.Id == foodItem.Id);

            if(result == null)
                return false;

            return true;
            
        }

        public MyCart GetCartItem(FoodItem foodItem)
        {
            return this._dbContext.MyCart.SingleOrDefault(f => f.Food.Id == foodItem.Id);
        }

        public int GetCartItemsQuantity()
        {
            int cnt = 0;

            foreach(var tempCart in this._dbContext.MyCart.ToList())
            {
                cnt += tempCart.ItemQuantity;
            }

            return cnt;
        }

        public List<MyCart> GetCart()
        {
            return this._dbContext.MyCart.ToList();
        }

        public decimal GetTotalAmount()
        {
            decimal totalAmount = 0;

            foreach (var tempCart in this._dbContext.MyCart.ToList())
            {
                totalAmount += tempCart.ItemQuantity * this._foodItemRepo.GetFoodItemById(tempCart.FoodId).Price;
            }

            return totalAmount;
        }

        public void ClearCart()
        {
            _dbContext.Database.ExecuteSqlRaw("DELETE from dbo.MyCart");
        }
    }
}
