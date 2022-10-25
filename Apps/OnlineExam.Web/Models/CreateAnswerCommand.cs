namespace OnlineExam.Web.Models
{
    public class CreateAnswerCommand
    {
        public int QuestionId { get; set; }

        public string Code { get; set; }
    }
}
