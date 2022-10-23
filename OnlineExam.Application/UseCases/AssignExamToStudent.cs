using OnlineExam.Application.PersistencePorts;
using OnlineExam.Domain.Entities;
using OnlineExam.Domain.UseCases;

namespace OnlineExam.Application.UseCases
{
    public class AssignExamToStudent : IAssignExamToStudent
    {
        private readonly IAssignmentPersistencePort assignmentPersistencePort;

        public AssignExamToStudent(IAssignmentPersistencePort assignmentPersistencePort)
        {
            this.assignmentPersistencePort = assignmentPersistencePort;
        }

        public async Task<List<Assignment>> ShowAssignmentBelongToStudent(int studentId)
        {
            return assignmentPersistencePort.GetAssignmentListWithStudentId(studentId);
        }

        public async Task<int> CreateAssignment(Assignment assignment)
        {
            return assignmentPersistencePort.CreateAssignment(assignment);
        }

        public void CompleteExam(Assignment assignment)
        {
            throw new NotImplementedException();
        }

        public void CreateExamLink(Assignment assignment)
        {
            throw new NotImplementedException();
        }

        public void IsLinkValid(Assignment assignment)
        {
            throw new NotImplementedException();
        }

        public void ShowExamResult(Assignment assignment)
        {
            throw new NotImplementedException();
        }
    }
}
