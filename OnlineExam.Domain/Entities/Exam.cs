using OnlineExam.Domain.Entities.Base;

namespace OnlineExam.Domain.Entities
{
    public class Exam : IEntityBase<int>
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Header { get; set; }       
    }
}
