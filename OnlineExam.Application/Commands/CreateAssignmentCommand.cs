using MediatR;
using OnlineExam.Application.Responses;

namespace OnlineExam.Application.Commands
{
    public class CreateAssignmentCommand : IRequest<AssignmentResponse>
    {
        public int StudentId { get; set; }

        public string ExamCode { get; set; }
    }
}
