using MediatR;
using OnlineExam.Application.Responses;

namespace OnlineExam.Application.Commands
{
    public class CreateStudentCommand : IRequest<StudentResponse>
    {
        public string Name { get; set; }

        public string Surname { get; set; }
    }
}
