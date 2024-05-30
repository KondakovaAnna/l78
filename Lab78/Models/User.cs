using System.Text;
using Microsoft.Build.Framework;
using Microsoft.IdentityModel.Tokens;

namespace Lab78.Models;

public class User
{
    [Required]
    public string Login { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string Role { get; set; }
}
//public class AuthenticationOptions
//{
//    public const string ISSUER = "MyAuthServer"; // издатель токена
//    public const string AUDIENCE = "MyAuthClient"; // потребитель токена
//    const string KEY = "mysupersecret_secretkey!123";   // ключ для шифрации
//    public const int LIFETIME = 2; // время жизни токена - 2 мин
//    public static SymmetricSecurityKey GetSymmetricSecurityKey()
//    {
//        return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
//    }
//}