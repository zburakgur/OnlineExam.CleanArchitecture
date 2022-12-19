using System.Linq.Expressions;
using System.Transactions;
using Infrastructure.Base;
using Infrastructure.DbContext.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ReadOnlyRepository<T, TId> : IReadOnlyRepository<T, TId> where T : class, IEntityBase<TId>
    {
        protected DbSet<T> Table;
        
        protected readonly IContext context;

        public ReadOnlyRepository(IContext context)
            => this.context = context;

        public IQueryable<T> GetTable()
            => Table ??= context.Set<T>();
        
        private TransactionScope CreateNoLockTransaction()
        {
            var options = new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted };
            return new TransactionScope(TransactionScopeOption.Required, options, TransactionScopeAsyncFlowOption.Enabled);
        }
        
        public async Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            using (CreateNoLockTransaction())
            {
                return await Table.FirstOrDefaultAsync(match);
            }
        }

        public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            using (CreateNoLockTransaction())
            {
                return await Table.Where(match).ToListAsync();
            }
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> filter)
        {
            using (CreateNoLockTransaction())
            {
                return await Table.AnyAsync(filter);
            }
        }

        public async Task<T> GetAsync(TId id)
        {
            using (CreateNoLockTransaction())
            {
                return await Table.FindAsync(id);
            }
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> filter)
        {
            using (CreateNoLockTransaction())
            {
                return await Table.CountAsync(filter).ConfigureAwait(false);
            }
        }
    }
}