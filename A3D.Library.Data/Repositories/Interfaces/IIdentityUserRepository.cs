using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace A3D.Library.Data.Repositories.Interfaces
{
    public interface IIdentityUserRepository
    {
        IQueryable<IdentityUser> GetByUsername(string username);
    }
}
