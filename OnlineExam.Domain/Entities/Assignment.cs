using Infrastructure.Base;

namespace OnlineExam.Domain.Entities
{
    public class Assignment : IEntityBase<int>
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public string ExamCode { get; set; }

        public bool IsCompleted { get; set; }

        public int Score { get; set; }

        public DateTime? CompletedDate { get; set; }

        public DateTime Deadline { get; set; }
    }
}
