using Infrastrkture.Commands;
using Infrastrkture.Commands.Accounts;
using Infrastrkture.Services;
using System.Threading.Tasks;

namespace Infrastrkture.Handlers.Accounts
{
    public class GetAccountHandler : ICommandHandler<GetAccount>
    {
        private readonly IAccountService _accountService;

        public GetAccountHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task Handle(GetAccount command)
        {
            await _accountService.Login(command.Email, command.Password);
        }
    }
}
