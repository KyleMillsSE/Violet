using DotNetCore2.EF.Commands.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DotNetCore2.EF.Commands
{
    public class EntityInsertCommand<TMdl> : IEntityInsertCommand<TMdl>
        where TMdl : class
    {
        private CoreContext _context;
        private DbSet<TMdl> _dbset;

        public EntityInsertCommand(CoreContext context)
        {
            _context = context;
            _dbset = context.Set<TMdl>();
        }

        public async Task<TMdl> ExecuteAsync(TMdl entity)
        {
            await _dbset.AddAsync(entity);

            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
