namespace OnlineExam.Application.Commands
{
    public class CreateAssignmentCommand
    {
        public int StudentId { get; set; }

        public int ExamId { get; set; }

        public bool IsCompleted { get; set; }

        public int Score { get; set; }

        public DateTime? CompletedDate { get; set; }

        public DateTime Deadline { get; set; }
    }
}
