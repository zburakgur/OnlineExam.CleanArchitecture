using OnlineExam.Domain.Entities;

namespace OnlineExam.Application.PersistencePorts
{
    public interface IExamEnrollmentPersistencePort
    {
        int CreateExam(Exam exam);

        Exam GetExamWithId(int id);
    }
}
