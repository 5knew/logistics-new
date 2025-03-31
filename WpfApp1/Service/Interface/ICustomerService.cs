using WpfApp1.Model;
namespace WpfApp1.Service.Interface
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<IEnumerable<Customer>> GetCustomersWithDetailsAsync();
        Task<IEnumerable<Customer>> SearchCustomersAsync(string keyword);
        Task AddCustomerAsync(Customer customer);
    }
}