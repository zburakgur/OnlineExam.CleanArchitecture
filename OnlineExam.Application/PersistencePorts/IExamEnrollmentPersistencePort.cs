using OnlineExam.Domain.Entities;
using System.IO;

namespace OnlineExam.Application.PersistencePorts
{
    public interface IExamEnrollmentPersistencePort
    {
        List<Question> GetQuestionListWithExamId(string examCode, string path);

        List<Exam> GetExamList();

        Exam GetExamWithId(int id);
    }
}
