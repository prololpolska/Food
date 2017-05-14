using Core.Domain;
using Infrastructure.DTO;
using System.Threading.Tasks;

namespace Infrastrkture.Services
{
    public interface IAccountService : IService
    {
        Task<AccountDTO> Add(string userName, string email, string password);
        Task<AccountDTO> Login(string email, string password);
        Task<Account> Get(int id);
        Task<AccountDTO> Map(Account account);
    }
}
