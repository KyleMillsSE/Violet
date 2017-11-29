using DotNetCore2.EF.Commands.Core;
using DotNetCore2.Model.Entities;
using System.Threading.Tasks;

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
