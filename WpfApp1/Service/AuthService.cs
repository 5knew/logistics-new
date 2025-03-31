using System.Security.Cryptography;
using System.Text;
using WpfApp1.Data;
using WpfApp1.Model;
using WpfApp1.Repository;
using WpfApp1.Service;
using WpfApp1;
using WpfApp1.Service.Interface;
namespace WpfApp1.Service
{
    public class AuthService : IAuthService
    {
        private readonly IUserAccountRepository _userRepository;

        public AuthService(IUserAccountRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserAccount?> AuthenticateAsync(string username, string password)
        {
            var user = await _userRepository.FindAsync(u => u.Username == username);
            var userAccount = user.FirstOrDefault();

            if (userAccount != null)
            {
                if (VerifyPassword(password, userAccount.PasswordHash))
                {
                    return userAccount;
                }

                var newHash = BCrypt.Net.BCrypt.HashPassword(password);
                userAccount.PasswordHash = newHash;
                await _userRepository.UpdateAsync(userAccount);
            }

            return null;
        }

        public async Task<bool> RegisterAsync(string username, string password, string role)
        {
            var existing = await _userRepository.FindAsync(u => u.Username == username);
            if (existing.Any()) return false;

            var hashed = BCrypt.Net.BCrypt.HashPassword(password);
            var user = new UserAccount
            {
                Username = username,
                PasswordHash = hashed,
                Role = role
            };

            await _userRepository.AddAsync(user);
            return true;
        }

        private bool VerifyPassword(string password, string storedHash)
        {
            try
            {
                return BCrypt.Net.BCrypt.Verify(password, storedHash);
            }
            catch (BCrypt.Net.SaltParseException)
            {
                return false;
            }
        }

        // AuthService.cs (реализация GetAllUsersAsync)
        public async Task<IEnumerable<UserAccount>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task CreateFullAccountAsync(UserAccount user)
        {
            await _userRepository.AddAsync(user);
        }

        public async Task<IEnumerable<UserAccount>> GetAllWithProfilesAsync()
        {
            return await _userRepository.GetAllWithProfilesAsync();
        }

    }




}