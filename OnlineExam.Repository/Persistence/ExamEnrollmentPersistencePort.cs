using OnlineExam.Application.PersistencePorts;
using OnlineExam.Domain.Entities;

namespace OnlineExam.Repository.Persistence
{
    public class ExamEnrollmentPersistencePort : IExamEnrollmentPersistencePort
    {
        private readonly IOnlineExamRepository<Exam, int> examRepository;
        private readonly IOnlineExamRepository<Question, int> questionRepository;

        public ExamEnrollmentPersistencePort(IOnlineExamRepository<Exam, int> examRepository,
                                             IOnlineExamRepository<Question, int> questionRepository)
        {
            this.examRepository = examRepository;
            this.questionRepository = questionRepository;
        }

        public List<Question> GetQuestionListWithExamId(int examId)
        {
            return (from record in questionRepository.GetTable()
                    where record.ExamId == examId
                    select record).ToList();
        }

        public List<Exam> GetExamList()
        {
            List<Exam> result =  (from record in examRepository.GetTable()
                                  select record).ToList();

            return result;
        }

        public int CreateExam(Exam exam)
        {
            if (exam == default)
                throw new ArgumentNullException("CreateExam");

            if (exam.Questions == default || exam.Questions.Count == 0)
                throw new ArgumentNullException("CreateExam");

            return examRepository.AddAsync(exam).Result;
        }

        public Exam GetExamWithId(int id)
        {
            Exam result =  (from record in examRepository.GetTable()
                            where record.Id == id
                            select record).FirstOrDefault();

            result.Questions = (from record in questionRepository.GetTable()
                                where record.ExamId == result.Id
                                select record).ToList();

            return result;
        }
    }
}
