using Core.Repositories;
using System;
using Core.Domain;
using System.Threading.Tasks;

namespace Infrastrkture.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public Task Add(Account account)
        {
            throw new NotImplementedException();
        }

        public Task<Account> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, Account account)
        {
            throw new NotImplementedException();
        }
    }
}
