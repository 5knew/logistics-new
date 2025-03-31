using WpfApp1.Data;
using WpfApp1.Model;
using WpfApp1.Repository;
using WpfApp1.Service;
using WpfApp1;

namespace WpfApp1.Repository
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersWithDetailsAsync();
        Task<IEnumerable<Order>> GetByStatusAsync(OrderStatus status);
        Task<IEnumerable<Order>> GetByDateRangeAsync(DateTime start, DateTime end);
        Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(int customerId);
    }
}