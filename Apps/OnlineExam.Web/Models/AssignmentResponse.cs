namespace OnlineExam.Web.Models
{
    public class AssignmentResponse
    {
        public string ExamCode { get; set; }

        public bool IsCompleted { get; set; }

        public int Score { get; set; }

        public DateTime Deadline { get; set; }
    }
}
