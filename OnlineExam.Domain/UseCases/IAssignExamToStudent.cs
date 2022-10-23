using OnlineExam.Domain.Entities;
using OnlineExam.Domain.UseCases.Base;

namespace OnlineExam.Domain.UseCases
{
    public interface IAssignExamToStudent : IUseCaseBase
    {
        Task<List<Assignment>> ShowAssignmentBelongToStudent(int studentId);

        Task<int> CreateAssignment(Assignment assignment);

        Task<List<Exam>> ShowExamListForStudentAssignment(int studentId, string path);

        void IsLinkValid(Assignment assignment);

        void CreateExamLink(Assignment assignment);

        void CompleteExam(Assignment assignment);

        void ShowExamResult(Assignment assignment);
    }
}
