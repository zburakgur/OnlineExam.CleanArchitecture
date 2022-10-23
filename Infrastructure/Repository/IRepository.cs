using Infrastructure.DbContext.Base;

namespace Infrastructure.Repository
{
    public interface IRepository<T, TId> where T : class
    {
        IQueryable<T> GetTable();

        Task<ICollection<T>> AddAsync(ICollection<T> entities);

        Task<TId> AddAsync(T entity);

        Task DeleteAsync(ICollection<T> entities);

        Task<ICollection<T>> UpdateAsync(ICollection<T> entities);

        Task<T> UpdateAsync(TId key, T entity);
    }
}
