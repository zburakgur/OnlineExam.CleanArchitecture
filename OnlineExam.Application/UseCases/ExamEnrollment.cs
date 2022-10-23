using OnlineExam.Application.PersistencePorts;
using OnlineExam.Domain.Entities;
using OnlineExam.Domain.UseCases;

namespace OnlineExam.Application.UseCases
{
    public class ExamEnrollment : IExamEnrollment
    {
        private readonly IExamEnrollmentPersistencePort examEnrollemtPersistencePort;

        public ExamEnrollment(IExamEnrollmentPersistencePort examEnrollemtPersistencePort)
        {
            this.examEnrollemtPersistencePort = examEnrollemtPersistencePort;
        }

        public async Task<int> CreateExam(Exam exam)
        {
            return examEnrollemtPersistencePort.CreateExam(exam);
        }

        public async Task<Exam> GetExamWithId(int id)
        {
            return examEnrollemtPersistencePort.GetExamWithId(id);
        }
    }
}
