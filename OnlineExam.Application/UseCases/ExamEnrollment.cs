using OnlineExam.Application.PersistencePorts;
using OnlineExam.Domain.Entities;
using OnlineExam.Domain.UseCases;

namespace OnlineExam.Application.UseCases
{
    public class ExamEnrollment : IExamEnrollment
    {
        private readonly IExamEnrollmentPersistencePort examEnrollemtPersistencePort;

        public async Task<List<Question>> ShowQuestionListBelongToExam(string examCode, string path)
        {
            return examEnrollemtPersistencePort.GetQuestionListWithExamId(examCode, path);
        }

        public ExamEnrollment(IExamEnrollmentPersistencePort examEnrollemtPersistencePort)
        {
            this.examEnrollemtPersistencePort = examEnrollemtPersistencePort;
        }

        public async Task<List<Exam>> ShowExamList(string path)
        {
            return examEnrollemtPersistencePort.GetExamList(path);
        }
    }
}
