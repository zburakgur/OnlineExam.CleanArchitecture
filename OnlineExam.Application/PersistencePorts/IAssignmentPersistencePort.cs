using OnlineExam.Domain.Entities;

namespace OnlineExam.Application.PersistencePorts
{
    public interface IAssignmentPersistencePort
    {
        int CreateAssignment(Assignment assignment);
    }
}
