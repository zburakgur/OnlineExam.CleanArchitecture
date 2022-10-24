using AutoMapper;
using MediatR;
using OnlineExam.Application.Queries;
using OnlineExam.Application.Responses;
using OnlineExam.Domain.Ports;

namespace OnlineExam.Application.Handlers
{
    public class GetExamListAvailableForStudentHandler : IRequestHandler<GetExamListAvailableForStudentQuery, List<ExamResponse>>
    {
        private readonly IRepositoryPort _repositoryPort;
        private readonly IMapper _mapper;

        public GetExamListAvailableForStudentHandler(IRepositoryPort _repositoryPort, IMapper _mapper)
        {
            this._repositoryPort = _repositoryPort;
            this._mapper = _mapper;
        }

        public async Task<List<ExamResponse>> Handle(GetExamListAvailableForStudentQuery request, CancellationToken cancellationToken)
        {
            var examList = await _repositoryPort.GetExamListNotAssignedToStudent(request.StudentId, request.Path);

            var response = _mapper.Map<List<ExamResponse>>(examList);
            return response;
        }
    }
}
