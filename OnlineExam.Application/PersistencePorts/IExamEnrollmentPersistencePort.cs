using OnlineExam.Domain.Entities;

namespace OnlineExam.Application.PersistencePorts
{
    public interface IExamEnrollmentPersistencePort
    {
        List<Question> GetQuestionListWithExamId(int examId);

        List<Exam> GetExamList();

        int CreateExam(Exam exam);

        Exam GetExamWithId(int id);
    }
}
