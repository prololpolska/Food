using Core.Domain;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IAccountRepository : IRepository
    {
        Task<Account> Get(int id);
        Task<Account> Get(string  email);
        Task Add(Account account);
        Task<int> GetId();
    }
}
