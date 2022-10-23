using Infrastructure.DbContext.Base;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Repository
{
    public interface IOnlineExamRepository<T, TId> : IRepository<T, TId> where T : class
    {
    }
}
