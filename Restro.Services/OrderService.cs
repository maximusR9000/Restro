using Restro.Models;
using Restro.Services;

namespace Restro.Services
{
    public class OrderService : IOrderService
    {
        private readonly ProjectDBContext _dbContext;
        public OrderService(ProjectDBContext dBContext)
        {
            this._dbContext = dBContext;
        }

        public Order GetOrderById(int id)
        {
            return this._dbContext.Orders.SingleOrDefault(o => o.Id == id);
        }

        public List<OrderDetails> GetOrderDetailsById(int id)
        {
            return this._dbContext.Orders.SingleOrDefault(o => o.Id == id).OrderDetails.ToList();
        }

        public OrderDetails GetOrderDetails(int id)
        {
            return this._dbContext.OrderDetails.SingleOrDefault(o => o.Id == id);
        }
        public List<OrderDetails> GetOrderDetailsByUser(int id)
        {
            return this._dbContext.OrderDetails.Where(o => o.UserId == id).ToList();
        }
        
        public List<Order> GetOrdersByUser(int id)
        {
            return this._dbContext.Orders.Where(o => o.UserId == id).ToList();
        }

        public Order AddOrder(Order newOrder)
        {
            this._dbContext.Orders.Add(newOrder);
            this._dbContext.SaveChanges();

            return newOrder;
        }
        
        public OrderDetails AddOrderDetails(OrderDetails newOrderDetails)
        {
            this._dbContext.OrderDetails.Add(newOrderDetails);
            this._dbContext.SaveChanges();

            return newOrderDetails;
        }
    }
}
