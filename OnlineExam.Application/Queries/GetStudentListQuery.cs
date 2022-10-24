using MediatR;
using OnlineExam.Application.Responses;

namespace OnlineExam.Application.Queries
{
    public class GetStudentListQuery : IRequest<List<StudentResponse>>
    {
    }
}
