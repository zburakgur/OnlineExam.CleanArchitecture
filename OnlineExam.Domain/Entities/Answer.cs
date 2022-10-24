using Infrastructure.Base;

namespace OnlineExam.Domain.Entities
{
    public class Answer : IEntityBase<int>
    {
        public int Id { get; set; }

        public int AssignmentId { get; set; }

        public int QuestionId { get; set; }

        public string Code { get; set; }
    }
}
