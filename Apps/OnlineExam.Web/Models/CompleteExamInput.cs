namespace OnlineExam.Web.Models
{
    public class CompleteExamInput
    {
        public int AssignmentId { get; set; }

        public List<CreateAnswerCommand> AnswerList { get; set; }
    }
}
