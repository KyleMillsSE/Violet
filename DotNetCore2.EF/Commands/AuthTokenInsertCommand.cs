using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DotNetCore2.Models.Entities;
using DotNetCore2.EF.Commands.Core;

namespace DotNetCore2.EF.Commands
{
    public class AuthTokenInsertCommand : IAuthTokenInsertCommand
    {
        private readonly IEntityInsertCommand<AuthToken> _entityInsertCommand;

        public AuthTokenInsertCommand(IEntityInsertCommand<AuthToken> entityInsertCommand)
        {
            _entityInsertCommand = entityInsertCommand;
        }

        public async Task<AuthToken> ExecuteAsync(AuthToken authToken)
        {
            return await _entityInsertCommand.ExecuteAsync(authToken);
        }
    }
}
