using Core.Repositories;
using Core.Domain;
using System.Threading.Tasks;
using Infrastrkture.Connections;

namespace Infrastrkture.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public async Task Add(Account account)
        {
            var addAccount = new AddAccount();
            addAccount.Add(account);
        }

        public async Task<Account> Get(int id)
        {
            var getAccount = new GetAccount();
            return await getAccount.WhereId(id);
        }

        public async Task<Account> Get(string email)
        {
            var getAccount = new GetAccount();
            return await getAccount.WhereEmail(email);
        }

        public async Task<int> GetId()
        {
            var getMaxId = new GetMaxId();
            return getMaxId.Get();
        }
    }
}
