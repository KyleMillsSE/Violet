using DotNetCore2.Model.Entities;
using System;

namespace DotNetCore2.Services
{
    public class CurrentApplicationUserService
    {
        private static Guid? UserId;

        public Guid GetCurrentUser() => UserId ?? CoreUser.KnownUserIds.CoreAdminUser;
        public void SetCurrentUser(Guid userId) => UserId = userId;
        public void SetCurrentUser(string userId) => UserId = Guid.Parse(userId);
    }
}
