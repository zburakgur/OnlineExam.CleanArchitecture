using Newtonsoft.Json;
using OnlineExam.Application.PersistencePorts;
using OnlineExam.Domain.Entities;

namespace OnlineExam.Repository.Persistence
{
    public class ExamEnrollmentPersistencePort : IExamEnrollmentPersistencePort
    {
        private readonly IOnlineExamRepository<Exam, int> examRepository;

        public ExamEnrollmentPersistencePort(IOnlineExamRepository<Exam, int> examRepository)
        {
            this.examRepository = examRepository;
        }

        public List<Question> GetQuestionListWithExamId(string examCode, string path)
        {
            var jsonData = System.IO.File.ReadAllText(path+examCode+".json");
            if (string.IsNullOrWhiteSpace(jsonData))
                throw new Exception("GetQuestionListWithExamId");

            var result = JsonConvert.DeserializeObject<List<Question>>(jsonData);
            return result;
        }

        public List<Exam> GetExamList()
        {
            List<Exam> result =  (from record in examRepository.GetTable()
                                  select record).ToList();

            return result;
        }

        public Exam GetExamWithId(int id)
        {
            return  (from record in examRepository.GetTable()
                     where record.Id == id
                     select record).FirstOrDefault();
        }
    }
}
