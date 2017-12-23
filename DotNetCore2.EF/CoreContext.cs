using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DotNetCore2.EF
{
    public class CoreContext : IdentityDbContext<IdentityUser>
    {
        public CoreContext(DbContextOptions<CoreContext> options) : base(options) {
            
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
