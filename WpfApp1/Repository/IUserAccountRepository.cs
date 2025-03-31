using WpfApp1.Model;

namespace WpfApp1.Repository
{
    public interface IUserAccountRepository : IRepository<UserAccount>
    {
        /// <summary>
        /// Получить одного пользователя с полной информацией (контакты, документы, адреса, фото + профили).
        /// </summary>
        Task<UserAccount?> GetFullProfileByIdAsync(int id);

        /// <summary>
        /// Получить всех пользователей с их профилями и связанной информацией.
        /// </summary>
        Task<IEnumerable<UserAccount>> GetAllWithProfilesAsync();
    }
}
