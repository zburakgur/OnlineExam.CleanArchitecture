﻿using OnlineExam.Application.PersistencePorts;
using OnlineExam.Domain.Entities;

namespace OnlineExam.Repository.Persistence
{
    public class AssignmentPersistencePort : IAssignmentPersistencePort
    {
        private readonly IOnlineExamRepository<Student, int> studentRepository;
        private readonly IOnlineExamRepository<Assignment, int> assignmentRepository;

        public AssignmentPersistencePort(IOnlineExamRepository<Student, int> studentRepository,
                                         IOnlineExamRepository<Assignment, int> assignmentRepository)
        {
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

            Assignment tmp = (from record in assignmentRepository.GetTable()
                              where record.StudentId == assignment.StudentId &&
                                    record.ExamCode == assignment.ExamCode
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
