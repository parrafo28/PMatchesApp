using Microsoft.EntityFrameworkCore;
using PMatches.Domain.Core;
using PMatches.Persistence;

namespace PMatches.Infrastructure.Core
{
    public class BaseRepository<T> where T : BaseEntity
    {
        protected readonly DataContext Context;
        public BaseRepository(DataContext context)
        {
            Context = context;
        }
        public async Task<List<T>> GetAll()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public async Task<T> GetEntityById(int id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public async Task<int> Add(T entity)
        {
            Context.Set<T>().Add(entity);
            await Context.SaveChangesAsync();
            return entity.Id;

        }
        public async Task<bool> Update(T entity)
        {
            Context.Set<T>().Update(entity);
            await Context.SaveChangesAsync();
            return true;
        }
    }
}
