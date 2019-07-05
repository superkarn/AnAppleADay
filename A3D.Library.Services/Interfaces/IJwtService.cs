using A3D.Library.Models;

namespace A3D.Library.Services.Interfaces
{
    public interface IJwtService
    {
        JwtUser Authenticate(string username, string password);
    }
}
