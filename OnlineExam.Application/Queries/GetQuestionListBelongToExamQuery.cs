using MediatR;
using OnlineExam.Application.Responses;

namespace OnlineExam.Application.Queries
{
    public class GetQuestionListBelongToExamQuery : IRequest<List<QuestionResponse>>
    {
        public string ExamCode { get; set; }

        public string QuestionsPath { get; set; }
    }
}
