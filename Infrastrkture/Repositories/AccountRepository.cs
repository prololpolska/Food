using Core.Repositories;
using Core.Domain;
using System.Threading.Tasks;
using Infrastrkture.Connections;
using System;

namespace Infrastrkture.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public async Task Add(Account account)
        {
            var addAccount = new AddAccount();
            int added = await addAccount.Add(account);
            if(added == 0)
            {
                throw new Exception("Nie można dodać użytkownika");
            }
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
    }
}
