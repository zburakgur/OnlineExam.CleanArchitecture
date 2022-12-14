using AutoMapper;
using MediatR;
using OnlineExam.Application.Queries;
using OnlineExam.Application.Responses;
using OnlineExam.Domain.Ports;

namespace OnlineExam.Application.Handlers
{
    public class GetQuestionListBelongToExamHandler : IRequestHandler<GetQuestionListBelongToExamQuery, List<QuestionResponse>>
    {
        private readonly IRepositoryPort _repositoryPort;
        private readonly IMapper _mapper;

        public GetQuestionListBelongToExamHandler(IRepositoryPort _repositoryPort, IMapper _mapper)
        {
            this._repositoryPort = _repositoryPort;
            this._mapper = _mapper;
        }

        public async Task<List<QuestionResponse>> Handle(GetQuestionListBelongToExamQuery request, CancellationToken cancellationToken)
        {
            var questionList = await _repositoryPort.GetQuestionListWithExamCode(request.ExamCode, request.QuestionsPath);

            var response = _mapper.Map<List<QuestionResponse>>(questionList);
            return response;
        }
    }
}
