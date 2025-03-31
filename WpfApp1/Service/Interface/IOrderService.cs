// IOrderService
using WpfApp1.Model;
namespace WpfApp1.Service.Interface
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<IEnumerable<Order>> GetOrdersByStatusAsync(OrderStatus status);
        Task<IEnumerable<Order>> GetOrdersByDateRangeAsync(DateTime start, DateTime end);
        Task<IEnumerable<Order>> GetOrdersByCustomerAsync(int customerId);
    }
}