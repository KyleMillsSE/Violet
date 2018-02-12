using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetCore2.Model.Entities.Identity;
using Microsoft.EntityFrameworkCore;

namespace DotNetCore2.EF.Queries.Users
{
    public class GetUserById : IGetUserById
    {
        private readonly ICoreGetAllQuery<CoreUser> _getByIdQuery;

        public GetUserById(ICoreGetAllQuery<CoreUser> getByIdQuery) => _getByIdQuery = getByIdQuery;


        public CoreUser Execute(Guid userId)
        {
            return _getByIdQuery
                .Execute()
                .Include(x => x.SecurityProfile.SecurityProfileClaims.Select(y => y.Claim))
                .FirstOrDefault(x => x.Id == userId);
        }
    }
}
