using OnlineExam.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Entities
{
    public class Exam : IEntityBase<int>
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Header { get; set; }
       
        public virtual List<Question> Questions { get; set; }
    }
}
