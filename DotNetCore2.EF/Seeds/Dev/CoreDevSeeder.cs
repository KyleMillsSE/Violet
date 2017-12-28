using DotNetCore2.Model.Entities;
using DotNetCore2.Services.Helpers;
using System;
using System.Collections.Generic;

namespace DotNetCore2.EF.Seeds.Dev
{
    public static class CoreDevSeeder
    {
        public static void Seed(CoreContext context)
        {
            context.Users.AddRange(new List<CoreUser>() {
                new CoreUser(){ Id = CoreUser.KnownUserIds.CoreAdminUser, Email = "KMillssd@gmail.com", Username = "KyleMills", Password = CryptoHelperWrapper.HashPassword("CoreDevelopment1!"), IsDeleted = false },
                new CoreUser(){ Id = Guid.Empty, Email = "Testd@gmail.com", Username = "Test1", Password = CryptoHelperWrapper.HashPassword("CoreDevelopment1!"), IsDeleted = false },
                new CoreUser(){ Id = Guid.Empty, Email = "Test123@gmail.com", Username = "Test2", Password = CryptoHelperWrapper.HashPassword("CoreDevelopment1!"), IsDeleted = false },
                new CoreUser(){ Id = Guid.Empty, Email = "Test3333@gmail.com", Username = "Test4", Password = CryptoHelperWrapper.HashPassword("CoreDevelopment1!"), IsDeleted = false }
            });
            context.SaveChanges();
        }
    }
}
