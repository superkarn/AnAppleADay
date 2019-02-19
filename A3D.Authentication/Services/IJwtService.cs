using A3D.Authentication.Models;

namespace A3D.Authentication.Services
{
    public interface IJwtService
    {
        User Authenticate(string username, string password);
    }
}
