using WpfApp1.Data;
using WpfApp1.Model;
using WpfApp1.Repository;
using WpfApp1.Service;
using WpfApp1;
using WpfApp1.Service.Interface;
namespace WpfApp1.Service
{
    // CustomerService.cs (реализация ICustomerService)
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _customerRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Customer>> GetCustomersWithDetailsAsync()
        {
            return await _customerRepository.GetWithAllDetailsAsync();
        }

        public async Task<IEnumerable<Customer>> SearchCustomersAsync(string keyword)
        {
            return await _customerRepository.SearchByCompanyNameAsync(keyword);
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            await _customerRepository.AddAsync(customer);
        }
    }
    }