using Infrastrkture.Commands;
using Infrastrkture.Commands.Accounts;
using Infrastrkture.Services;
using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;

namespace Infrastrkture.Handlers.Accounts
{
    public class GetAccountHandler : ICommandHandler<GetAccount>
    {
        private readonly IAccountService _accountService;
        private readonly IMemoryCache _memoryCache;

        public GetAccountHandler(IAccountService accountService, IMemoryCache memoryCache)
        {
            _accountService = accountService;
            _memoryCache = memoryCache;
        }

        public async Task Handle(GetAccount command)
        {
            _memoryCache.Set("accountDto", await _accountService.Login(command.Email, command.Password));
        }
    }
}
