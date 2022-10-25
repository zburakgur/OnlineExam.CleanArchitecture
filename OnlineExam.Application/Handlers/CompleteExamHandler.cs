using AutoMapper;
using MediatR;
using OnlineExam.Application.Commands;
using OnlineExam.Application.Responses;
using OnlineExam.Domain.Entities;
using OnlineExam.Domain.Ports;

namespace OnlineExam.Application.Handlers
{
    public class CompleteExamHandler : IRequestHandler<CompleteExamCommand, CompleteExamResponse>
    {
        private readonly IRepositoryPort _repositoryPort;
        private readonly IMapper _mapper;

        public CompleteExamHandler(IRepositoryPort _repositoryPort, IMapper _mapper)
        {
            this._repositoryPort = _repositoryPort;
            this._mapper = _mapper;
        }

        public async Task<CompleteExamResponse> Handle(CompleteExamCommand request, CancellationToken cancellationToken)
        {
            List<Answer> answerList = _mapper.Map<List<Answer>>(request.AnswerList);
            answerList.ForEach(x => x.AssignmentId = request.AssignmentId);

            await _repositoryPort.CreateAnswer(answerList);

            Assignment assignment = await _repositoryPort.CheckAssignment(request.AssignmentId);
            List<Question> questionList = await _repositoryPort.GetQuestionListWithExamCode(assignment.ExamCode, request.Path);




            throw new NotImplementedException();
        }
    }
}
