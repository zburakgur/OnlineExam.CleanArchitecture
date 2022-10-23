using OnlineExam.Domain.Entities.Base;

namespace OnlineExam.Domain.Entities
{
    public class Assignment : IEntityBase<int>
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int ExamId { get; set; }

        public bool IsCompleted { get; set; }

        public int Score { get; set; }

        public DateTime? CompletedDate { get; set; }

        public DateTime Deadline { get; set; }
    }
}
