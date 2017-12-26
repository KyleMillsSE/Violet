using System;

namespace DotNetCore2.App
{
    public class CurrentApplicationUserService
    {
        private static Guid UserId;

        public Guid GetCurrentUser() => UserId ?? 
        public void SetCurrentUser(Guid userId) => UserId = userId;
        public void SetCurrentUser(string userId) => UserId = Guid.Parse(userId);
    }
}
