using OnlineExam.Application.PersistencePorts;
using OnlineExam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Repository.Persistence
{
    public class UserEnrollmentPersistence : IUserEnrollemtPersistencePort
    {
        private readonly IOnlineExamRepository<Admin, int> adminRepository;
        private readonly IOnlineExamRepository<Student, int> studentRepository;

        public UserEnrollmentPersistence(IOnlineExamRepository<Admin, int> adminRepository, 
                                         IOnlineExamRepository<Student, int> studentRepository)
        {
            this.adminRepository = adminRepository;
            this.studentRepository = studentRepository;
        }

        public void SeedAdmin(Admin admin)
        {
            Admin result = (from record in adminRepository.GetTable()
                            where record.UserName == admin.UserName &&
                                  record.Password == admin.Password
                            select record).FirstOrDefault();

            if (result == default)
            {
                adminRepository.AddAsync(admin);
            }
        }

        public bool CheckAdmin(Admin admin)
        {
            if (admin == default)
                throw new ArgumentNullException("CheckAdmin");

            Admin result = (from record in adminRepository.GetTable()
                            where record.UserName == admin.UserName &&
                                  record.Password == admin.Password
                            select record).FirstOrDefault();

            return result != null;
        }

        public int CreateStudent(Student student)
        {
            if(student == default)
                throw new ArgumentNullException("CreateStudent");

            return studentRepository.AddAsync(student).Result;
        }

        public List<Student> GetStudentList()
        {
            return (from record in studentRepository.GetTable()
                    select record).ToList();
        }
    }
}
