using System.Threading.Tasks;

namespace DotNetCore2.EF.Commands.Contracts
{
    public interface IEntityInsertCommand<TMdl>
    {
        Task<TMdl> ExecuteAsync(TMdl entity);
    }
}
