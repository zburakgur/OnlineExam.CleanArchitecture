using Infrastructure.Base;
using Infrastructure.DbContext.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class Repository<T, TId> : IRepository<T, TId> where T : class, IEntityBase<TId>
    {
        protected readonly IContext context;

        private DbSet<T> entities;

        public Repository(IContext context)
            => this.context = context;

        protected DbSet<T> Table => entities ?? (entities = context.Set<T>());

        public IQueryable<T> GetTable() => Table;

        public async Task<TId> AddAsync(T entity)
        {
            Table.Add(entity);
            await context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<ICollection<T>> AddAsync(ICollection<T> entities)
        {
            if (entities == null || !entities.Any())
            {
                return entities;
            }

            await Table.AddRangeAsync(entities);
            await context.SaveChangesAsync();

            return entities;
        }

        public async Task<int> DeleteAsync(T entity)
        {
            Table.Remove(entity);

            return await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ICollection<T> entities)
        {
            if (entities == null || !entities.Any())
            {
                return;
            }

            Table.RemoveRange(entities);
            await context.SaveChangesAsync();
        }

        public async Task<ICollection<T>> UpdateAsync(ICollection<T> entities)
        {
            if (entities == null || !entities.Any())
            {
                return entities;
            }

            Table.UpdateRange(entities);
            await context.SaveChangesAsync();

            return entities;
        }

        public async Task<T> UpdateAsync(TId key, T entity)
        {
            if (entity == null)
            {
                return null;
            }

            var item = Table.Find(key);

            if (item == null)
            {
                return null;
            }

            Table.Update(entity);
            await context.SaveChangesAsync();

            return item;
        }
    }
}
