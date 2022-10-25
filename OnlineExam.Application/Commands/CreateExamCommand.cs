using OnlineExam.Domain.Entities;

namespace OnlineExam.Application.Commands
{
    public class CreateExamCommand
    {
        public string Code { get; set; }

        public string Header { get; set; }

        public List<Question> questions { get; set; }
    }
}
