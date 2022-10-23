using OnlineExam.Application.PersistencePorts;
using OnlineExam.Domain.Entities;
using OnlineExam.Domain.UseCases;

namespace OnlineExam.Application.UseCases
{
    public class UserEnrollment : IUserEnrollment
    {
        private readonly IUserEnrollemtPersistencePort userEnrollemtPersistencePort;

        public UserEnrollment(IUserEnrollemtPersistencePort userEnrollemtPersistencePort)
        {
            this.userEnrollemtPersistencePort = userEnrollemtPersistencePort;
        }

        public async Task<List<Student>> ShowStudentList()
        {
            return userEnrollemtPersistencePort.GetStudentList();
        }

        public async Task<bool> CheckAdmin(Admin admin)
        {
            userEnrollemtPersistencePort.SeedAdmin(new Admin()
            {
                UserName = "Admin",
                Password = "Password",
                Name = "TestAdminName",
                Surname = "TestAdminSurname",
            });

            return userEnrollemtPersistencePort.CheckAdmin(admin);
        }

        public async Task<int> CreateStudent(Student student)
        {
            return userEnrollemtPersistencePort.CreateStudent(student);
        }
    }
}
