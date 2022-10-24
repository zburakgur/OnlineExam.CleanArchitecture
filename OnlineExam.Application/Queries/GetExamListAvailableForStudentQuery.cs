using MediatR;
using OnlineExam.Application.Responses;

namespace OnlineExam.Application.Queries
{
    public class GetExamListAvailableForStudentQuery : IRequest<List<ExamResponse>>
    {
        public int StudentId { get; set; }

        public string Path { get; set; }
    }
}
