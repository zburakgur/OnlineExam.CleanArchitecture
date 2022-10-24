using Infrastructure.Base;
using Infrastructure.Repository;

namespace OnlineExam.Repository
{
    public class OnlineExamRepository<T, TId> : Repository<T, TId>, IOnlineExamRepository<T, TId> where T : class, IEntityBase<TId>
    {
        public OnlineExamRepository(IOnlineExamContext context) : base(context)
        {
        }
    }
}
