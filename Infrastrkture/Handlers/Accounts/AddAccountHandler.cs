using Infrastrkture.Commands;
using Infrastrkture.Commands.Accounts;
using Infrastrkture.Services;
using System.Threading.Tasks;

namespace Infrastrkture.Handlers.Accounts
{
    class AddAccountHandler : ICommandHandler<AddAccount>
    {
        private readonly IAccountService _accountService;
        
        public AddAccountHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task Handle(AddAccount command)
        {
            await _accountService.Add(command.Username, command.Email, command.Password);
        }
    }
}
