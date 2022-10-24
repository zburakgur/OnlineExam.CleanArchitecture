using AutoMapper;
using MediatR;
using OnlineExam.Application.Queries;
using OnlineExam.Application.Responses;
using OnlineExam.Domain.Ports;

namespace OnlineExam.Application.Handlers
{
    public class GetStudentListHandler : IRequestHandler<GetStudentListQuery, List<StudentResponse>>
    {
        private readonly IRepositoryPort _repositoryPort;
        private readonly IMapper _mapper;

        public GetStudentListHandler(IRepositoryPort _repositoryPort, IMapper _mapper)
        {
            this._repositoryPort = _repositoryPort;
            this._mapper = _mapper;
        }

        public async Task<List<StudentResponse>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var studentList = await _repositoryPort.GetStudentList();
            var response = _mapper.Map<List<StudentResponse>>(studentList);

            return response;
        }
    }
}
