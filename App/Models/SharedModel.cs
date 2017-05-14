namespace App.Models
{
    public class SharedModel
    {
        public string accountOrLogin { get; set; }
        public string accountOrLoginTarget { get; set; }

        public string getAccountOrLogin()
        {
            return accountOrLogin;
        }
        public SharedModel()
        {
            accountOrLogin = "Zaloguj się";
            accountOrLoginTarget = "Login";
        }
    }
}
