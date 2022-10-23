using OnlineExam.Application.PersistencePorts;
using OnlineExam.Domain.Entities;

namespace OnlineExam.Repository.Persistence
{
    public class AssignmentPersistencePort : IAssignmentPersistencePort
    {
        private readonly IOnlineExamRepository<Student, int> studentRepository;
        private readonly IOnlineExamRepository<Assignment, int> assignmentRepository;
        private readonly IExamEnrollmentPersistencePort examEnrollmentPersistencePort;

        public AssignmentPersistencePort(IOnlineExamRepository<Student, int> studentRepository,
                                         IOnlineExamRepository<Assignment, int> assignmentRepository,
                                         IExamEnrollmentPersistencePort examEnrollmentPersistencePort)
        {
            this.studentRepository = studentRepository;
            this.assignmentRepository = assignmentRepository;
            this.examEnrollmentPersistencePort = examEnrollmentPersistencePort;
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

            Assignment tmp = (from record in assignmentRepository.GetTable()
                              where record.StudentId == assignment.StudentId &&
                                    record.ExamCode == assignment.ExamCode
                              select record).FirstOrDefault();

            if (tmp != default)
                throw new ArgumentException("CreateAssignment");

            assignment.Score = 0;
            assignment.Deadline = DateTime.Now.AddDays(7);
            assignment.IsCompleted = false;

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

        public List<Exam> GetExamListNotAssignedToStudent(int studentId, string path)
        {
            List<Exam> examList = examEnrollmentPersistencePort.GetExamList(path);
            List<Assignment> assignmentList = (from record in assignmentRepository.GetTable()
                                               where record.StudentId == studentId
                                               select record).ToList();

            return (from exam in examList
                    join assignment in assignmentList on exam.Code equals assignment.ExamCode into joinList
                    from tmp in joinList.DefaultIfEmpty()
                    where tmp == default
                    select exam).ToList();
        }
    }
}
