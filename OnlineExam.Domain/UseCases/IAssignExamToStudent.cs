using OnlineExam.Domain.Entities;
using OnlineExam.Domain.UseCases.Base;

namespace OnlineExam.Domain.UseCases
{
    public interface IAssignExamToStudent : IUseCaseBase
    {
        Task<int> CreateAssignment(Assignment assignment);

        void IsLinkValid(Assignment assignment);

        void CreateExamLink(Assignment assignment);

        void CompleteExam(Assignment assignment);

        void ShowExamResult(Assignment assignment);
    }
}
