using OnlineExam.Domain.Entities;

namespace OnlineExam.Domain.Ports
{
    public interface IRepositoryPort
    {
        Task<int> CreateAssignment(Assignment assignment);

        Task<List<Assignment>> GetAssignmentListWithStudentId(int studentId);

        Task<List<Exam>> GetExamListNotAssignedToStudent(int studentId, string path);

        Task<List<Question>> GetQuestionListWithExamCode(string examCode, string path);

        Task<List<Exam>> GetExamList(string path);

        void SeedAdmin(Admin admin);

        Task<Admin> CheckAdmin(Admin admin);

        Task<int> CreateStudent(Student student);

        Task<List<Student>> GetStudentList();
    }
}
