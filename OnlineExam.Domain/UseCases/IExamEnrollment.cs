using OnlineExam.Domain.Entities;
using OnlineExam.Domain.UseCases.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.UseCases
{
    public interface IExamEnrollment : IUseCaseBase
    {
        Task<int> CreateExam(Exam exam);

        Task<Exam> GetExamWithId(int id);
    }
}
