using OnlineExam.Domain.Entities;

namespace OnlineExam.Application.PersistencePorts
{
    public interface IAssignmentPersistencePort
    {
        int CreateAssignment(Assignment assignment);

        List<Assignment> GetAssignmentListWithStudentId(int studentId);

        List<Exam> GetExamListNotAssignedToStudent(int studentId, string path);
    }
}
