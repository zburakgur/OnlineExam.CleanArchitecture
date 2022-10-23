using Infrastructure.DbContext.Base;
using Infrastructure.Repository;
using OnlineExam.Domain.Entities.Base;

namespace OnlineExam.Repository
{
    public class OnlineExamRepository<T, TId> : Repository<T, TId>, IOnlineExamRepository<T, TId> where T : class, IEntityBase<TId>
    {
        public OnlineExamRepository(IOnlineExamContext context) : base(context)
        {
        }
    }
}
