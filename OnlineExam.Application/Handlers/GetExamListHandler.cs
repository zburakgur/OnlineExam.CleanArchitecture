using AutoMapper;
using MediatR;
using OnlineExam.Application.Queries;
using OnlineExam.Application.Responses;
using OnlineExam.Domain.Ports;

namespace OnlineExam.Application.Handlers
{
    public class GetExamListHandler : IRequestHandler<GetExamListQuery, List<ExamResponse>>
    {
        private readonly IRepositoryPort _repositoryPort;
        private readonly IMapper _mapper;

        public GetExamListHandler(IRepositoryPort _repositoryPort, IMapper _mapper)
        {
            this._repositoryPort = _repositoryPort;
            this._mapper = _mapper;
        }

        public async Task<List<ExamResponse>> Handle(GetExamListQuery request, CancellationToken cancellationToken)
        {
            var examList = await _repositoryPort.GetExamList(request.Path);

            var response = _mapper.Map<List<ExamResponse>>(examList);
            return response;
        }
    }
}
