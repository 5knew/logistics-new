using WpfApp1.Data;
using WpfApp1.Model;
using WpfApp1.Repository;
using WpfApp1.Service;
using WpfApp1;
using System.Threading.Tasks;
namespace WpfApp1.Repository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<IEnumerable<Customer>> GetCustomersWithDetailsAsync();
        Task<IEnumerable<Customer>> SearchByCompanyNameAsync(string companyName);
        Task<IEnumerable<Customer>> GetCustomersWithContactsAsync();

        Task<IEnumerable<UserAccount>> GetAllWithProfilesAsync();
        Task<UserAccount?> GetFullProfileByIdAsync(int id);

        Task<IEnumerable<Customer>> GetWithAllDetailsAsync();

    }


}