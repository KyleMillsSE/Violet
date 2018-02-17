using DotNetCore2.Model.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCore2.EF.Queries.Users
{
    public interface IGetUserByUsernameQuery
    {
        CoreUser Execute(string username);
    }
}
