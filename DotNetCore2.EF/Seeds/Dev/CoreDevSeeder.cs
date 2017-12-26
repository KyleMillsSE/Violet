using DotNetCore2.Model.Entities;
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
                new CoreUser(){ Id = CoreReferenceData.CoreAdminUser, Email = "KMillssd@gmail.com", Username = "KyleMills", Password =  IsDeleted = false, }
            });
        }
    }
}
