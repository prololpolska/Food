using Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrkture.Services
{
    interface IAccountService : IService
    {
        Task Register(int id, string userName, string email, string password);
        Task Login(string email, string password);
        Task<AccountDTO> Get(string email);
        Task<AccountDTO> Get(int id);
    }
}
