using Microsoft.EntityFrameworkCore;
using WpfApp1.Data;
using WpfApp1.Model;

namespace WpfApp1.Repository
{
    public class UserAccountRepository : Repository<UserAccount>, IUserAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public UserAccountRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<UserAccount?> GetFullProfileByIdAsync(int id)
        {
            return await _context.UserAccounts
                .Include(u => u.Contacts)
                .Include(u => u.Documents)
                .Include(u => u.Images)
                .Include(u => u.Addresses)
                .Include(u => u.Customer)
                .Include(u => u.Driver)
                .Include(u => u.Admin)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<UserAccount>> GetAllWithProfilesAsync()
        {
            return await _context.UserAccounts
                .Include(u => u.Contacts)
                .Include(u => u.Documents)
                .Include(u => u.Images)
                .Include(u => u.Addresses)
                .Include(u => u.Customer)
                .Include(u => u.Driver)
                .Include(u => u.Admin)
                .ToListAsync();
        }
    }
}
