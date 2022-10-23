using OnlineExam.Domain.Entities;
using OnlineExam.Domain.UseCases.Base;

namespace OnlineExam.Domain.UseCases
{
    public interface IExamEnrollment : IUseCaseBase
    {
        Task<List<Question>> ShowQuestionListBelongToExam(int examId);

        Task<List<Exam>> ShowExamList();

        Task<int> CreateExam(Exam exam);

        Task<Exam> GetExamWithId(int id);
    }
}
