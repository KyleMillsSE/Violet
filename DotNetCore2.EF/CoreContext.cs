using DotNetCore2.Model.Entities;
using DotNetCore2.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq;
using System.Linq.Expressions;

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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<CoreUser>().HasOne(x => x.ModifiedBy).WithMany().HasForeignKey(x => x.ModifiedById);
            modelBuilder.Entity<CoreUser>().HasOne(x => x.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById);

            modelBuilder.Entity<CoreUserClaim>()
                .HasKey(x => new { x.UserId, x.ClaimId });

            modelBuilder.Entity<CoreUserClaim>()
                .HasOne(x => x.User)
                .WithMany(x => x.UserClaims)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<CoreUserClaim>()
                .HasOne(x => x.Claim)
                .WithMany(x => x.UserClaims)
                .HasForeignKey(x => x.ClaimId);

            base.OnModelCreating(modelBuilder);
        }

    }

}
