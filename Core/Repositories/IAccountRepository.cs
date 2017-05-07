using Core.Domain;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IAccountRepository : IRepository
    {
        Task<Account> Get(int id);
        Task Add(Account account);
        Task Update(int id, Account account);
        Task Remove(int id);
    }
}
