using System;

namespace DotNetCore2.Services
{
    public class CurrentApplicationUserService
    {
        private static Guid? UserId;

        public Guid GetCurrentUser() => UserId ?? throw new Exception("Current user id is null, something has gone wrong");
        public void SetCurrentUser(Guid userId) => UserId = userId;
        public void SetCurrentUser(string userId) => UserId = Guid.Parse(userId);
    }
}
