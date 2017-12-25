using DotNetCore2.Model.Entities;
using DotNetCore2.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DotNetCore2.EF
{
    public class CoreContext : DbContext
    {
        private readonly CurrentApplicationUserService _currentApplicationUserService;

        public CoreContext(DbContextOptions<CoreContext> options, 
            CurrentApplicationUserService currentApplicationUserService) 
            : base(options)
        {
            _currentApplicationUserService = currentApplicationUserService;
        }

        public DbSet<CoreUser> Users { get; set; }
        public DbSet<CoreClaim> Claims { get; set; }

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
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }


            builder.Entity<CoreClaim>().HasMany(x => x.DependancyClaims).WithMany();
            builder.Entity<CoreUser>().HasMany(x => x.Claims).WithMany(x => x.Users); // For some reason EF can't work out that this is a many to many without help

            base.OnModelCreating(builder);
        }
    }
}
