using OnlineExam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Commands
{
    public class CreateExamCommand
    {
        public string Code { get; set; }

        public string Header { get; set; }

        public List<Question> questions { get; set; }
    }
}
