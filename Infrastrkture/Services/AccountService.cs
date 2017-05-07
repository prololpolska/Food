using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.DTO;

namespace Infrastrkture.Services
{
    public class AccountService : IAccountService
    {
        public async Task<AccountDTO> Get(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<AccountDTO> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public async Task Register(int id, string userName, string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
