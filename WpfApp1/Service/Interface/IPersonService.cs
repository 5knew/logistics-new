using WpfApp1.Model;
namespace WpfApp1.Service.Interface
{
    public interface IPersonService<T> where T : PersonEntity
    {
        Task AddWithDetailsAsync(T person);
        Task<IEnumerable<T>> GetWithDetailsAsync();
    }
}