using Infrastructure.Base;

namespace OnlineExam.Domain.Entities
{
    public class Student : IEntityBase<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

    }
}
