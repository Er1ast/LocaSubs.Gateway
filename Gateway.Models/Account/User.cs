using System.ComponentModel.DataAnnotations;

namespace Gateway.Models.Account;

public class User
{
    [Key]
    public string Login { get; set; }
    public string Password { get; set; }

    public User(string login, string password)
    {
        Login = login;
        Password = password;
    }
}
