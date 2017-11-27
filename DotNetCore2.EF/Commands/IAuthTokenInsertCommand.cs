using DotNetCore2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCore2.EF.Commands
{
    public interface IAuthTokenInsertCommand
    {
        Task<AuthToken> ExecuteAsync(AuthToken authToken);
    }
}
