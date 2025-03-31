using System.Collections.Generic;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.Service.Interface
{
    public interface IDriverService
    {
        Task AddDriverAsync(Driver driver);
        Task<IEnumerable<Driver>> GetAllDriversAsync();
        Task<Driver?> GetDriverByIdAsync(int id);
        Task DeleteDriverAsync(int id);
    }
}
