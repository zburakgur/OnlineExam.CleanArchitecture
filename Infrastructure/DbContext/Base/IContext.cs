using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DbContext.Base
{
    public interface IContext
    {
        //void AddRange<T>(IEnumerable<T> entities) where T : class;

        //void ChangeState<T>(T entity, DomainState state) where T : class;

        //int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

        DbSet<T> Set<T>() where T : class;
    }
}
