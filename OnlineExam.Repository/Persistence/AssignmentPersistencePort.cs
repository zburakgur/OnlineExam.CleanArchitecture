using OnlineExam.Application.PersistencePorts;
using OnlineExam.Domain.Entities;

namespace OnlineExam.Repository.Persistence
{
    public class AssignmentPersistencePort : IAssignmentPersistencePort
    {
        private readonly IOnlineExamRepository<Exam, int> examRepository;
        private readonly IOnlineExamRepository<Student, int> studentRepository;
        private readonly IOnlineExamRepository<Assignment, int> assignmentRepository;

        public AssignmentPersistencePort(IOnlineExamRepository<Exam, int> examRepository,
                                         IOnlineExamRepository<Student, int> studentRepository,
                                         IOnlineExamRepository<Assignment, int> assignmentRepository)
        {
            this.examRepository = examRepository;
            this.studentRepository = studentRepository;
            this.assignmentRepository = assignmentRepository;
        }

        public int CreateAssignment(Assignment assignment)
        {
            if (assignment == default)
                throw new ArgumentNullException("CreateAssignment");

            Student student = (from record in studentRepository.GetTable()
                               where record.Id == assignment.StudentId
                               select record).FirstOrDefault();

            if (student == default)
                throw new ArgumentException("CreateAssignment");

            Exam exam = (from record in examRepository.GetTable()
                         where record.Id == assignment.ExamId
                         select record).FirstOrDefault();

            if (exam == default)
                throw new ArgumentException("CreateAssignment");

            Assignment tmp = (from record in assignmentRepository.GetTable()
                              where record.StudentId == assignment.StudentId &&
                                    record.ExamId == assignment.ExamId
                              select record).FirstOrDefault();

            if (tmp != default)
                throw new ArgumentException("CreateAssignment");

            return assignmentRepository.AddAsync(assignment).Result;
        }

        public List<Assignment> GetAssignmentListWithStudentId(int studentId)
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
    }
}
