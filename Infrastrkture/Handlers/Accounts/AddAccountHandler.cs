using Infrastrkture.Commands;
using Infrastrkture.Commands.Accounts;
using Infrastrkture.Services;
using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;

namespace Infrastrkture.Handlers.Accounts
{
    class AddAccountHandler : ICommandHandler<AddAccount>
    {
        private readonly IAccountService _accountService;
        private readonly IMemoryCache _memoryCache;

        public AddAccountHandler(IAccountService accountService, IMemoryCache memoryCache)
        {
            _accountService = accountService;
            _memoryCache = memoryCache;
        }

        public async Task Handle(AddAccount command)
        {
            await _accountService.Add(command.Username, command.Email, command.Password);
            _memoryCache.Set("accountDto", await _accountService.Login(command.Email, command.Password));
        }
    }
}
