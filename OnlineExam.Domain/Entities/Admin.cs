using Infrastructure.Base;

namespace OnlineExam.Domain.Entities
{
    public class Admin : IEntityBase<int>
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
    }
}
