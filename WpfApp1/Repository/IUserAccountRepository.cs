using WpfApp1.Model;

namespace WpfApp1.Repository
{
    public interface IUserAccountRepository : IRepository<UserAccount>
    {
        /// <summary>
        /// �������� ������ ������������ � ������ ����������� (��������, ���������, ������, ���� + �������).
        /// </summary>
        Task<UserAccount?> GetFullProfileByIdAsync(int id);

        /// <summary>
        /// �������� ���� ������������� � �� ��������� � ��������� �����������.
        /// </summary>
        Task<IEnumerable<UserAccount>> GetAllWithProfilesAsync();
    }
}
