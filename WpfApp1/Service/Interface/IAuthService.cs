using WpfApp1.Model;
namespace WpfApp1.Service.Interface
{
    public interface IAuthService
    {
        Task<UserAccount?> AuthenticateAsync(string username, string password);
        Task<bool> RegisterAsync(string username, string password, string role);
        Task<IEnumerable<UserAccount>> GetAllUsersAsync();

        Task CreateFullAccountAsync(UserAccount user);
        Task<IEnumerable<UserAccount>> GetAllWithProfilesAsync();


    }
}