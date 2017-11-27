using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCore2.EF.Commands.Core
{
    public interface IEntityInsertCommand<TMdl>
    {
        Task<TMdl> ExecuteAsync(TMdl entity);
    }
}
