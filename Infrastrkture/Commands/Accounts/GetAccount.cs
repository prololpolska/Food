namespace Infrastrkture.Commands.Accounts
{
    public class GetAccount : ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public GetAccount(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
