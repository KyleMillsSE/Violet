using DotNetCore2.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetCore2.EF
{
    public class CoreContext : IdentityDbContext<IdentityUser>
    {
        private readonly CurrentApplicationUserService _currentApplicationUserService;
        public CoreContext(DbContextOptions<CoreContext> options, CurrentApplicationUserService currentApplicationUserService) : base(options)
        {
            _currentApplicationUserService = currentApplicationUserService;
        }

       
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        /// <summary>
        /// use fluent api to customize db
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //add here...

            base.OnModelCreating(builder);
        }
    }
}
