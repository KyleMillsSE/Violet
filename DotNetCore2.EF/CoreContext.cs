using DotNetCore2.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCore2.EF
{
    public class CoreContext : IdentityDbContext<IdentityUser>
    {
        public CoreContext(DbContextOptions<CoreContext> options) : base(options) {
            
        }

        public DbSet<AuthToken> AuthTokens { get; set; }

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

public class Subscription
{
    public ICollection<license> Licenses { get; set; }
}

public class license
{
    public Guid UserId { get; set; }
}
