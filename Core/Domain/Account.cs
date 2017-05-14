using System;

namespace Core.Domain
{
    public class Account
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public DateTime DietEnd { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Salt { get; set; }
        public string Role { get; set; }
        public Account(int id, string userName, string email, string password, string salt, string role)
        {
            Id = id;
            UserName = userName;
            Email = email;
            Password = password;
            DietEnd = DateTime.UtcNow.Date.AddSeconds(-1);
            Role = role;
            Salt = salt;
        }
        public Account()
        { }
    }
}
