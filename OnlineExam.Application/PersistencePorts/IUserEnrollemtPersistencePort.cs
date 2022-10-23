using OnlineExam.Domain.Entities;

namespace OnlineExam.Application.PersistencePorts
{
    public interface IUserEnrollemtPersistencePort
    {
        void SeedAdmin(Admin admin);

        bool CheckAdmin(Admin admin);

        int CreateStudent(Student student);     
    }
}
