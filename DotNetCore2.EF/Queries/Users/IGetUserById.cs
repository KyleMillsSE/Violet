using DotNetCore2.Model.Entities.Identity;
using System;

namespace DotNetCore2.EF.Queries.Users
{
    public interface IGetUserById
    {
        CoreUser Execute(Guid userId);
    }
}
