using DotNetCore2.Model;
using DotNetCore2.Model.Contracts;
using DotNetCore2.Model.Entities.Identity;
using DotNetCore2.Services;
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
        public DbSet<CoreSecurityProfile> SecurityProfiles { get; set; }
        public DbSet<CoreSecurityProfileClaim> SecurityProfileClaims { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            var now = DateTime.Now;
            var userId = _currentApplicationUserService.GetCurrentUser();

            //Generate new guids for new entities if not populated by EF
            var newEntities = ChangeTracker.Entries<IEntity>().Where(x => x.State == EntityState.Added && x.Entity.Id == Guid.Empty);
            newEntities.ForEach(x => x.Entity.Id = Guid.NewGuid());

            var modifiedEntities = ChangeTracker.Entries<IMutableEntity>().Where(x => x.State == EntityState.Modified);
            foreach (var modifiedEntity in modifiedEntities)
            {
                modifiedEntity.Entity.ModifiedAt = now;
                modifiedEntity.Entity.ModifiedById = userId;
            }

            var createdMutableEntities = ChangeTracker.Entries<IMutableEntity>().Where(x => x.State == EntityState.Added);
            foreach (var createdEntity in createdMutableEntities)
            {
                createdEntity.Entity.CreatedAt = now;
                createdEntity.Entity.CreatedById = userId;
                createdEntity.Entity.ModifiedAt = now;
                createdEntity.Entity.ModifiedById = userId;
            }

            var createdImmutableEntities = ChangeTracker.Entries<IImmutableEntity>().Where(x => x.State == EntityState.Added);
            foreach (var createdEntity in createdImmutableEntities)
            {
                createdEntity.Entity.CreatedAt = now;
                createdEntity.Entity.CreatedById = userId;
            }

            return base.SaveChanges();
        }

        /// <summary>
        /// use fluent api to customize db
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            foreach (var pb in modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(string))
                .Select(p => modelBuilder.Entity(p.DeclaringEntityType.ClrType).Property(p.Name)))
            {
                pb.HasColumnType("nvarchar(2500)");
            }

            //Create one to one relantionships
            modelBuilder.Entity<CoreUser>().HasOne(x => x.ModifiedBy).WithMany().HasForeignKey(x => x.ModifiedById);
            modelBuilder.Entity<CoreUser>().HasOne(x => x.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById);

            //Create many to many relantionship between claim and user implementing middle man class to handle the relation
            modelBuilder.Entity<CoreSecurityProfileClaim>()
                .HasKey(x => new { x.SecurityProfileId, x.ClaimId });

            modelBuilder.Entity<CoreSecurityProfileClaim>()
                .HasOne(x => x.SecurityProfile)
                .WithMany(x => x.SecurityProfileClaims)
                .HasForeignKey(x => x.SecurityProfileId);

            modelBuilder.Entity<CoreSecurityProfileClaim>()
                .HasOne(x => x.Claim)
                .WithMany(x => x.SecurityProfileClaims)
                .HasForeignKey(x => x.ClaimId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
