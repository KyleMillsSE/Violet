using System.Threading.Tasks;

namespace DotNetCore2.EF.Commands.Contracts
{
    public interface ICoreEntityInsertCommand<TMdl>
    {
        Task<TMdl> ExecuteAsync(TMdl entity);
    }
}
