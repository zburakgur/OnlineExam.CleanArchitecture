using OnlineExam.Domain.Entities;
using OnlineExam.Domain.UseCases.Base;

namespace OnlineExam.Domain.UseCases
{
    public interface IUserEnrollment : IUseCaseBase
    {
        Task<List<Student>> ShowStudentList();

        Task<int> CreateStudent(Student student);

        Task<bool> CheckAdmin(Admin admin);
    }
}
