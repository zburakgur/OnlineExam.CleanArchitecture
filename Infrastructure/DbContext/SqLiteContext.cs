using Infrastructure.DbContext.Base;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.DbContext
{
    public class SqLiteContext : Microsoft.EntityFrameworkCore.DbContext, IContext
    {
        protected readonly string connection;

        public SqLiteContext(string connection)
        {
            this.connection = connection;
            Database.SetCommandTimeout(300);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies(false)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .UseSqlite(connectionString: connection);                
        }
    }
}
