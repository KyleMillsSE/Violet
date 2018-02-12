using DotNetCore2.Model.Entities.Identity;
using DotNetCore2.Services.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetCore2.EF.Seeds.Dev
{
    public static class CoreDevSeeder
    {
        public static void Seed(CoreContext context)
        {
            context.Clear<CoreSecurityProfileClaim>();
            context.Clear<CoreUser>();
            context.Clear<CoreClaim>();
            context.Clear<CoreSecurityProfile>();

            // claims
            context.Claims.AddRange(new List<CoreClaim>()
            {
                new CoreClaim() { Id = CoreClaim.KnownCoreClaimIds.ViewUser, Reference = "View Users", Description = "Ability to view all user records"},
                new CoreClaim() { Id = CoreClaim.KnownCoreClaimIds.EditUser, Reference = "Edit User", Description = "Ability to edit and update user records"},
                new CoreClaim() { Id = CoreClaim.KnownCoreClaimIds.DeleteUser, Reference = "Delete Users", Description = "Ability to delete user records"},
                new CoreClaim() { Id = CoreClaim.KnownCoreClaimIds.AddUser, Reference = "Add Users", Description = "Ability to add new user records"},
            });
            context.SaveChanges();

            // security profiles
            context.SecurityProfiles.AddRange(new List<CoreSecurityProfile>()
            {
                new CoreSecurityProfile() { Id = CoreSecurityProfile.KnownCoreSecurityProfileIds.SuperAdminSecurityProfile, Reference = "Super admin", Description = "Ability to perform all system critical functions" },
                new CoreSecurityProfile() { Id = CoreSecurityProfile.KnownCoreSecurityProfileIds.AdminSecurityProfile, Reference = "Admin", Description = "Ability to perform some system critical functions" },
                new CoreSecurityProfile() { Id = CoreSecurityProfile.KnownCoreSecurityProfileIds.UserSecurityProfile, Reference = "User", Description = "Ability to perform none system critical functions" }
            });
            context.SaveChanges();

            // admin security profile
            context.SecurityProfiles
                .Where(sp => sp.Id == CoreSecurityProfile.KnownCoreSecurityProfileIds.SuperAdminSecurityProfile)
                .ToList()
                .Select(sp => sp.SecurityProfileClaims = context.Claims.Select(c => new CoreSecurityProfileClaim() { ClaimId = c.Id, SecurityProfileId = sp.Id }).ToList());
            context.SaveChanges();

            context.Users.AddRange(new List<CoreUser>() {
                new CoreUser() { Id = CoreUser.KnownCoreUserIds.CoreAdminUser, SecurityProfileId = CoreSecurityProfile.KnownCoreSecurityProfileIds.SuperAdminSecurityProfile, Email = "Kmillssoftwareengineer@gmail.com", Username = "KyleMills", Password = CryptoHelperWrapper.HashPassword("CoreDevelopment1!"), IsDeleted = false },
            });
            context.SaveChanges();
            context.Users.Find(CoreUser.KnownCoreUserIds.CoreAdminUser).SecurityProfileId = CoreSecurityProfile.KnownCoreSecurityProfileIds.SuperAdminSecurityProfile;
            context.SaveChanges();

            // users
            context.Users.AddRange(new List<CoreUser>() {

                new CoreUser(){ Id = Guid.Empty, SecurityProfileId = CoreSecurityProfile.KnownCoreSecurityProfileIds.UserSecurityProfile, Email = "Testd@gmail.com", Username = "Test1", Password = CryptoHelperWrapper.HashPassword("CoreDevelopment1!"), IsDeleted = false },
                new CoreUser(){ Id = Guid.Empty, SecurityProfileId = CoreSecurityProfile.KnownCoreSecurityProfileIds.UserSecurityProfile, Email = "Test123@gmail.com", Username = "Test2", Password = CryptoHelperWrapper.HashPassword("CoreDevelopment1!"), IsDeleted = false },
                new CoreUser(){ Id = Guid.Empty, SecurityProfileId = CoreSecurityProfile.KnownCoreSecurityProfileIds.UserSecurityProfile, Email = "Test3333@gmail.com", Username = "Test4", Password = CryptoHelperWrapper.HashPassword("CoreDevelopment1!"), IsDeleted = false }
            });
            context.SaveChanges();
        }
    }
}
