using System;

namespace DotNetCore2.Services
{
    public class ApplicationUserContext 
    {
        private static Guid UserId = Guid.NewGuid();

        public Guid GetCurrentUser() => new Guid(UserId.ToString());
        public void SetCurrentUser(Guid userId) => UserId = userId;
        public void SetCurrentUser(string userId) => UserId = Guid.Parse(userId);
    }
}
