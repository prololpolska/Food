using Core.Domain;
using Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrkture.Services
{
    public interface IAccountService : IService
    {
        Task<AccountDTO> Add(string userName, string email, string password);
        Task<AccountDTO> Login(string email, string password);
        Task<Account> Get(int id);
    }
}
