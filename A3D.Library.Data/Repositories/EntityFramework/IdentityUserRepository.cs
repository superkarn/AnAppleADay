using A3D.Library.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace A3D.Authentication.Repositories.EntityFramework
{
    public class IdentityUserRepository : IIdentityUserRepository
    {
        protected readonly IdentityDbContext Context;
        protected readonly DbSet<IdentityUser> DbSet;

        public IdentityUserRepository(IdentityDbContext context)
        {
            this.Context = context;
            this.DbSet = this.Context.Set<IdentityUser>();
        }

        public IQueryable<IdentityUser> GetByUsername(string username)
        {
            return this.DbSet.Where(x => x.NormalizedUserName == username.ToUpper());
        }
    }
}
