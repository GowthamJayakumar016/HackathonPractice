using jwtauthentication.Models;

namespace jwtauthentication.Services
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
