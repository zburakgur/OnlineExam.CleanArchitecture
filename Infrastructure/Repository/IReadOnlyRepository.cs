using System.Linq.Expressions;
using Infrastructure.Base;

namespace Infrastructure.Repository;

public interface IReadOnlyRepository<T, TId> where T : class, IEntityBase<TId>
{
    IQueryable<T> GetTable();
    
    Task<T> FindAsync(Expression<Func<T, bool>> match);
    
    Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match);
    
    Task<bool> AnyAsync(Expression<Func<T, bool>> filter);
    
    Task<T> GetAsync(TId id);
    
    Task<int> CountAsync(Expression<Func<T, bool>> filter);
}