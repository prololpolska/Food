using System;
using System.Threading.Tasks;
using Infrastructure.DTO;
using Infrastrkture.Repositories;
using AutoMapper;
using Core.Repositories;
using Core.Domain;

namespace Infrastrkture.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEncrypter _encrypter;
        private readonly IMapper _mapper;
        private Account CurrentAccount { get;  set; }

        public AccountService(IAccountRepository accountRepository, IEncrypter encrypter, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _encrypter = encrypter;
            _mapper = mapper;
        }

        public async Task<AccountDTO> Login(string email, string password)
        {
            var account = await _accountRepository.Get(email);
            var salt = _encrypter.GetSalt(password);
            var hash = _encrypter.GetHash(password, salt);
            if (account.Password == hash)
            {
                return await Map(account);
            }else
            {
                return null;
            }
        }

        public async Task<Account> Get(int id)
        {
            return await _accountRepository.Get(id);
        }

        public async Task<AccountDTO> Add(string userName, string email, string password)
        {
            int id = await _accountRepository.GetId() + 1;
            var salt = _encrypter.GetSalt(password);
            var hash = _encrypter.GetHash(password, salt);
            var account = new Account(id, userName, email, hash);
            if(account == null)
            {
                return null;
            }
            await _accountRepository.Add(account);
            if(await _accountRepository.Get(id) != null)
            {
                return await Map(account);
            }
            return null;
        }

        public async Task<AccountDTO> Map(Account account)
        {
            return _mapper.Map<Account, AccountDTO>(account);
        }
    }
}
