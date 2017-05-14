using System;

namespace Infrastructure.DTO
{
    public class AccountDTO
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public DateTime DietEnd { get; set; }
    }
}
