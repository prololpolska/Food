using System.Threading.Tasks;
using Infrastructure.DTO;
using AutoMapper;
using Core.Repositories;
using Core.Domain;
using Infrastrkture.Connections;
using System;

namespace Infrastrkture.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEncrypter _encrypter;
        private readonly IMapper _mapper;

        public AccountService(IAccountRepository accountRepository, IEncrypter encrypter, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _encrypter = encrypter;
            _mapper = mapper;
        }

        public async Task<AccountDTO> Login(string email, string password)
        {
            var account = await _accountRepository.Get(email);
            if(account == null)
            {
                throw new Exception("Nie poprawny email lub hasło");
            }
            var hash = _encrypter.GetHash(password, account.Salt);
            if (account.Password == hash)
            {
                return await Map(account);
            }else
            {
                throw new Exception("Nie poprawny email lub hasło");
            }
        }

        public async Task<Account> Get(int id)
        {
            return await _accountRepository.Get(id);
        }

        public async Task Add(string userName, string email, string password)
        {
            var emailAlreadyExists = new EmailAlreadyExists();
            var userNameAlreadyExists = new UserNameAlreadyExists();
            var salt = _encrypter.GetSalt(password);
            var hash = _encrypter.GetHash(password, salt);
            var account = new Account(userName, email, hash, salt, "User");
            if(account == null)
            {
                throw new Exception("Nie można sworzyć użytkownika");
            }
            if(await emailAlreadyExists.Exist(account.Email))
            {
                throw new Exception("Podany email jest już używany");
            }
            if (await userNameAlreadyExists.Exist(account.UserName))
            {
                throw new Exception("Podana nazwa użytkownika jest już używana");
            }
            await _accountRepository.Add(account);
        }

        public async Task<AccountDTO> Map(Account account)
        {
            return _mapper.Map<Account, AccountDTO>(account);
        }
    }
}
