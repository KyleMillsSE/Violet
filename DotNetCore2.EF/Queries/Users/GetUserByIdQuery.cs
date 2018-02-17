using DotNetCore2.Model.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DotNetCore2.EF.Queries.Users
{
    public class GetUserByIdQuery : IGetUserByIdQuery
    {
        private readonly ICoreGetAllQuery<CoreUser> _getAllQuery;

        public GetUserByIdQuery(ICoreGetAllQuery<CoreUser> getAllQuery) => _getAllQuery = getAllQuery;


        public CoreUser Execute(Guid userId)
        {
            return _getAllQuery
                .Execute()
                .Include(x => x.SecurityProfile)
                .ThenInclude(x => x.SecurityProfileClaims)
                .ThenInclude(x => x.Claim)
                .FirstOrDefault(x => x.Id == userId);
        }
    }
}
