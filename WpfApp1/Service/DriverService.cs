using System.Collections.Generic;
using System.Threading.Tasks;
using WpfApp1.Model;
using WpfApp1.Repository;
using WpfApp1.Service.Interface;

namespace WpfApp1.Service
{
    public class DriverService : IDriverService
    {
        private readonly IRepository<Driver> _driverRepository;

        public DriverService(IRepository<Driver> driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public async Task AddDriverAsync(Driver driver)
        {
            await _driverRepository.AddAsync(driver);
        }

        public async Task<IEnumerable<Driver>> GetAllDriversAsync()
        {
            return await _driverRepository.GetAllAsync();
        }

        public async Task<Driver?> GetDriverByIdAsync(int id)
        {
            return await _driverRepository.GetByIdAsync(id);
        }

        public async Task DeleteDriverAsync(int id)
        {
            await _driverRepository.DeleteAsync(id);
        }
    }
}
