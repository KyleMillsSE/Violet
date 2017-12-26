using DotNetCore2.Model.Entities;
using DotNetCore2.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCore2.EF.Seeds.Dev
{
    public static class CoreDevSeeder
    {
        public static void Seed(CoreContext context)
        {
            context.Users.AddOrUpdate(new List<CoreUser>() {
                new CoreUser(){ Id = CoreReferenceData.CoreAdminUser, Email = "KMillssd@gmail.com", Username = "KyleMills", Password = CryptoHelperService.HashPassword("CoreDevelopment1!"), IsDeleted = false }
                new CoreUser(){ Id = CoreReferenceData.CoreAdminUser, Email = "KMillssd@gmail.com", Username = "KyleMills", Password = CryptoHelperService.HashPassword("CoreDevelopment1!"), IsDeleted = false }
            });
        }
    }
}
