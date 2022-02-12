using Restro.Models;

namespace Restro.Services
{
    public interface IOrderService
    {
        Order GetOrderById(int id);
        List<OrderDetails> GetOrderDetailsById(int id);
        OrderDetails GetOrderDetails(int id);
        List<OrderDetails> GetOrderDetailsByUser(int id);
        Order AddOrder(Order newOrder);
        OrderDetails AddOrderDetails(OrderDetails newOrderDetails);
        List<Order> GetOrdersByUser(int id);
    }
}
