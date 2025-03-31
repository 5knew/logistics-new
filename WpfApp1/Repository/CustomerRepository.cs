using Microsoft.EntityFrameworkCore;
using WpfApp1.Data;
using WpfApp1.Model;
using WpfApp1.Repository;
using WpfApp1.Service;
using WpfApp1;

namespace WpfApp1.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Customer>> GetCustomersWithDetailsAsync()
        {
            return await _context.UserAccounts
                .Where(u => u.Customer != null)
                .Include(u => u.Contacts)
                .Include(u => u.Documents)
                .Include(u => u.Images)
                .Include(u => u.Addresses)
                .Select(u => u.Customer!)
                .ToListAsync();
        }

        public async Task<IEnumerable<Customer>> GetWithAllDetailsAsync()
        {
            return await _context.UserAccounts
                .Where(u => u.Customer != null)
                .Include(u => u.Contacts)
                .Include(u => u.Documents)
                .Include(u => u.Images)
                .Include(u => u.Addresses)
                .Include(u => u.Customer)
                .Select(u => u.Customer!)
                .ToListAsync();
        }


        public async Task<IEnumerable<Customer>> SearchByCompanyNameAsync(string companyName)
        {
            return await _context.Customers
                .Where(c => c.CompanyName.Contains(companyName))
                .ToListAsync();
        }

        public async Task<IEnumerable<UserAccount>> GetAllWithProfilesAsync()
        {
            return await _context.UserAccounts
                .Where(u => u.Customer != null)
                .Include(u => u.Contacts)
                .Include(u => u.Documents)
                .Include(u => u.Images)
                .Include(u => u.Addresses)
                .Include(u => u.Customer)
                .ToListAsync();
        }

        public async Task<UserAccount?> GetFullProfileByIdAsync(int id)
        {
            return await _context.UserAccounts
                .Include(u => u.Contacts)
                .Include(u => u.Documents)
                .Include(u => u.Images)
                .Include(u => u.Addresses)
                .Include(u => u.Customer)
                .FirstOrDefaultAsync(u => u.Id == id && u.Customer != null);
        }

        public async Task<IEnumerable<Customer>> GetCustomersWithContactsAsync()
        {
            return await _context.UserAccounts
                .Where(u => u.Customer != null)
                .Include(u => u.Contacts)
                .Select(u => u.Customer!)
                .ToListAsync();
        }



    }
}