using MediatR;
using OnlineExam.Application.Responses;

namespace OnlineExam.Application.Queries
{
    public class GetAssignmentListBelongToStudentQuery : IRequest<List<AssignmentResponse>>
    {
        public int studentId { get; set; }
    }
}
