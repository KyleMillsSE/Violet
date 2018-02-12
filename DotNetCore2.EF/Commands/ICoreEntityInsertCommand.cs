using System.Threading.Tasks;

namespace DotNetCore2.EF.Commands
{
    public interface ICoreEntityInsertCommand<TMdl>
    {
        Task<TMdl> ExecuteAsync(TMdl entity);
    }
}
