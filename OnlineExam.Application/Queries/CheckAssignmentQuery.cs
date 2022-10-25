using MediatR;
using OnlineExam.Application.Responses;

namespace OnlineExam.Application.Queries
{
    public class CheckAssignmentQuery : IRequest<CheckAssignmentResponse>
    {
        public int AssignmentId { get; set; }

        public string Path { get; set; }
    }
}
