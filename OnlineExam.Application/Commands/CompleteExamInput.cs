namespace OnlineExam.Application.Commands
{
    public class CompleteExamInput
    {
        public int AssignmentId { get; set; }

        public List<CreateAnswerCommand> AnswerList { get; set; }
    }
}
