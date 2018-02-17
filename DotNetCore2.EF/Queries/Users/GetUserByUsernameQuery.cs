using DotNetCore2.Model.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DotNetCore2.EF.Queries.Users
{
    public class GetUserByUsernameQuery : IGetUserByUsernameQuery
    {
        private readonly ICoreGetAllQuery<CoreUser> _getAllQuery;

        public GetUserByUsernameQuery(ICoreGetAllQuery<CoreUser> getAllQuery) => _getAllQuery = getAllQuery;

        public CoreUser Execute(string username)
        {
            return _getAllQuery
                .Execute()
                .Include(x => x.SecurityProfile)
                .ThenInclude(x => x.SecurityProfileClaims)
                .ThenInclude(x => x.Claim)
                .FirstOrDefault(x => x.Username == username);
        }
    }
}
