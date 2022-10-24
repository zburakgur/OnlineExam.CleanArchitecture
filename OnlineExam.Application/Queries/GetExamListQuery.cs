using MediatR;
using OnlineExam.Application.Responses;

namespace OnlineExam.Application.Queries
{
    public class GetExamListQuery : IRequest<List<ExamResponse>>
    {
        public string Path { get; set; }
    }
}
