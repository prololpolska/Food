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
        public Account(int id, string userName, string email, string password)
        {
            Id = id;
            UserName = userName;
            Email = email;
            Password = password;
            DietEnd = DateTime.UtcNow.Date.AddSeconds(-1);
        }
        public Account()
        { }
    }
}
