using DotNetCore2.Model.Contracts;
using DotNetCore2.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DotNetCore2.EF
{
    public class CoreContext : DbContext
    {
        private readonly CurrentApplicationUserService _currentApplicationUserService;

        public CoreContext(DbContextOptions<CoreContext> options, CurrentApplicationUserService currentApplicationUserService)
            : base(options)
        {
            _currentApplicationUserService = currentApplicationUserService;
        }

        public DbSet<CoreUser> Users { get; set; }
        public DbSet<CoreClaim> Claims { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            var now = DateTime.Now;
            var userId = _currentApplicationUserService.GetCurrentUser();

            //Generate new guids for new entities
            var newEntities = ChangeTracker.Entries<IEntity>().Where(x => x.State == EntityState.Added && x.Entity.Id == Guid.Empty);
            newEntities.ForEach(x => x.Entity.Id = Guid.NewGuid());

            var modifiedEntities = ChangeTracker.Entries<IAuditedEntity>().Where(x => x.State == EntityState.Modified);
            foreach (var modifiedEntity in modifiedEntities)
            {
                modifiedEntity.Entity.ModifiedAt = now;
                modifiedEntity.Entity.ModifiedById = userId;
            }

            var createdEntities = ChangeTracker.Entries<IAuditedEntity>().Where(x => x.State == EntityState.Added);
            foreach (var modifiedEntity in modifiedEntities)
            {
                modifiedEntity.Entity.CreatedAt = now;
                modifiedEntity.Entity.CreatedById = userId;
                modifiedEntity.Entity.ModifiedAt = now;
                modifiedEntity.Entity.ModifiedById = userId;
            }

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

            //Create one to one relantionships
            modelBuilder.Entity<CoreUser>().HasOne(x => x.ModifiedBy).WithMany().HasForeignKey(x => x.ModifiedById);
            modelBuilder.Entity<CoreUser>().HasOne(x => x.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById);

            //Create many to many relantionship between claim and user implementing middle man class to handle the relation
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
