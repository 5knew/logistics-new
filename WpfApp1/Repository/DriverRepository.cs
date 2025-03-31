using WpfApp1.Data;
using WpfApp1.Model;
using WpfApp1.Repository;

namespace WpfApp1.Repository
{
    public class DriverRepository : Repository<Driver>, IRepository<Driver>
    {
        public DriverRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
