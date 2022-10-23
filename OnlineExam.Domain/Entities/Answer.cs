using OnlineExam.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
