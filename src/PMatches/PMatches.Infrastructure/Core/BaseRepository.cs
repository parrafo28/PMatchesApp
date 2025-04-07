using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PMatches.Domain.Core;
using PMatches.Persistence;
using System.Linq.Expressions;

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

        public async Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<int> Add(T entity)
        {
            Context.Set<T>().Add(entity);
            return entity.Id;

        }
        public async Task<bool> Update(T entity)
        {
            Context.Set<T>().Update(entity);
            return true;
        }



    }
}
