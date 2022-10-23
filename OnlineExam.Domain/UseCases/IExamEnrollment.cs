using OnlineExam.Domain.Entities;
using OnlineExam.Domain.UseCases.Base;

namespace OnlineExam.Domain.UseCases
{
    public interface IExamEnrollment : IUseCaseBase
    {
        Task<List<Question>> ShowQuestionListBelongToExam(string examCode, string path);

        Task<List<Exam>> ShowExamList();

        Task<Exam> GetExamWithId(int id);
    }
}
