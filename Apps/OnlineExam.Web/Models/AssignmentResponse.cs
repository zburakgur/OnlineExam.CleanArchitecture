namespace OnlineExam.Web.Models
{
    public class AssignmentResponse
    {
        public int Id { get; set; }

        public string ExamCode { get; set; }

        public bool IsCompleted { get; set; }

        public int Score { get; set; }

        public DateTime Deadline { get; set; }
    }
}
