using Newtonsoft.Json;
using OnlineExam.Domain.Entities;
using OnlineExam.Domain.Ports;

namespace OnlineExam.Repository.Repository
{
    public class RepositoryPort : IRepositoryPort
    {
        private readonly IOnlineExamRepository<Admin, int> adminRepository;
        private readonly IOnlineExamRepository<Student, int> studentRepository;
        private readonly IOnlineExamRepository<Assignment, int> assignmentRepository;
        private readonly IOnlineExamRepository<Answer, int> answerRepository;

        public RepositoryPort(IOnlineExamRepository<Admin, int> adminRepository,
                          IOnlineExamRepository<Student, int> studentRepository,
                          IOnlineExamRepository<Assignment, int> assignmentRepository,
                          IOnlineExamRepository<Answer, int> answerRepository)
        {
            this.adminRepository = adminRepository;
            this.studentRepository = studentRepository;
            this.assignmentRepository = assignmentRepository;
            this.answerRepository = answerRepository;
        }

        public async Task<Admin> CheckAdmin(Admin admin)
        {
            if (admin == default)
                throw new ArgumentNullException("CheckAdmin");

            return (from record in adminRepository.GetTable()
                    where record.UserName == admin.UserName &&
                            record.Password == admin.Password
                    select record).FirstOrDefault();
        }

        public async Task<Assignment> CheckAssignment(int assignmentId)
        {
            return (from record in assignmentRepository.GetTable()
                    where record.Id == assignmentId
                    select record).FirstOrDefault();
        }

        public async Task<int> CreateAssignment(Assignment assignment)
        {
            if (assignment == default)
                throw new ArgumentNullException("CreateAssignment");

            Student student = (from record in studentRepository.GetTable()
                               where record.Id == assignment.StudentId
                               select record).FirstOrDefault();

            if (student == default)
                throw new ArgumentException("CreateAssignment");

            Assignment tmp = (from record in assignmentRepository.GetTable()
                              where record.StudentId == assignment.StudentId &&
                                    record.ExamCode == assignment.ExamCode
                              select record).FirstOrDefault();

            if (tmp != default)
                throw new ArgumentException("CreateAssignment");

            assignment.Score = 0;
            assignment.Deadline = DateTime.Now.AddDays(7);
            assignment.IsCompleted = false;

            return await assignmentRepository.AddAsync(assignment);
        }

        public async Task<int> CreateStudent(Student student)
        {
            if (student == default)
                throw new ArgumentNullException("CreateStudent");

            return await studentRepository.AddAsync(student);
        }

        public async Task<List<Assignment>> GetAssignmentListWithStudentId(int studentId)
        {
            Student student = (from record in studentRepository.GetTable()
                               where record.Id == studentId
                               select record).FirstOrDefault();

            if (student == default)
                throw new ArgumentException("GetAssignmentListWithStudentId");

            var result = (from record in assignmentRepository.GetTable()
                          where record.StudentId == studentId
                          select record).ToList();

            return result;
        }

        public async Task<List<Exam>> GetExamList(string path)
        {
            DirectoryInfo d = new DirectoryInfo(path);
            FileInfo[] Files = d.GetFiles("*.json");

            List<Exam> result = new List<Exam>();
            foreach (FileInfo file in Files)
            {
                result.Add(new Exam()
                {
                    Code = file.Name.Split(".")[0]
                });
            }

            return result;
        }

        public async Task<List<Exam>> GetExamListNotAssignedToStudent(int studentId, string path)
        {
            List<Exam> examList = await GetExamList(path);
            List<Assignment> assignmentList = (from record in assignmentRepository.GetTable()
                                               where record.StudentId == studentId
                                               select record).ToList();

            return (from exam in examList
                    join assignment in assignmentList on exam.Code equals assignment.ExamCode into joinList
                    from tmp in joinList.DefaultIfEmpty()
                    where tmp == default
                    select exam).ToList();
        }

        public async Task<List<Question>> GetQuestionListWithExamCode(string examCode, string path)
        {
            var jsonData = System.IO.File.ReadAllText(path + "\\" + examCode + ".json");
            if (string.IsNullOrWhiteSpace(jsonData))
                throw new Exception("GetQuestionListWithExamId");

            var result = JsonConvert.DeserializeObject<List<Question>>(jsonData);
            return result;
        }

        public async Task<List<Student>> GetStudentList()
        {
            return (from record in studentRepository.GetTable()
                    select record).ToList();
        }

        public async Task<Student> GetStudentWithId(int studentId)
        {
            return (from record in studentRepository.GetTable()
                    where record.Id == studentId
                    select record).FirstOrDefault();
        }

        public async Task CreateAnswer(List<Answer> list)
        {
            await answerRepository.AddAsync(list);
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
    }
}
