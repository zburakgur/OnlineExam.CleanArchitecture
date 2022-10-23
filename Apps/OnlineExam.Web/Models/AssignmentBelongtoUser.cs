using OnlineExam.Domain.Entities;

namespace OnlineExam.Web.Models
{
    public class AssignmentBelongtoUser
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int ExamId { get; set; }

        public string Code { get; set; }

        public string Header { get; set; }

        public bool IsCompleted { get; set; }

        public int Score { get; set; }

        public DateTime? CompletedDate { get; set; }

        public DateTime Deadline { get; set; }

    }
}
