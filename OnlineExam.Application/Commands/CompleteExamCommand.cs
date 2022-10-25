using MediatR;
using OnlineExam.Application.Responses;

namespace OnlineExam.Application.Commands
{
    public class CompleteExamCommand : IRequest<CompleteExamResponse>
    {
        public int AssignmentId { get; set; }

        public List<CreateAnswerCommand> AnswerList { get; set; }

        public string Path { get; set; }
    }
}
