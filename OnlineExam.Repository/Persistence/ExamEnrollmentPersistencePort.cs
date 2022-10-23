using Newtonsoft.Json;
using OnlineExam.Application.PersistencePorts;
using OnlineExam.Domain.Entities;

namespace OnlineExam.Repository.Persistence
{
    public class ExamEnrollmentPersistencePort : IExamEnrollmentPersistencePort
    {
        public List<Question> GetQuestionListWithExamId(string examCode, string path)
        {
            var jsonData = System.IO.File.ReadAllText(path + "\\" + examCode+".json");
            if (string.IsNullOrWhiteSpace(jsonData))
                throw new Exception("GetQuestionListWithExamId");

            var result = JsonConvert.DeserializeObject<List<Question>>(jsonData);
            return result;
        }

        public List<Exam> GetExamList(string path)
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
    }
}
