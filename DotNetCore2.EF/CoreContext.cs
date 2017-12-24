using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using DotNetCore2.Services;

namespace DotNetCore2.EF
{
    public class CoreContext : IdentityDbContext<IdentityUser>
    {
        public CoreContext(DbContextOptions<CoreContext> options, ApplicationUserContext applicationUserContext) : base(options)
        {
            
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
