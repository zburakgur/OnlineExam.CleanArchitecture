using AutoMapper;
using MediatR;
using OnlineExam.Application.Queries;
using OnlineExam.Application.Responses;
using OnlineExam.Domain.Ports;

namespace OnlineExam.Application.Handlers
{
    public class GetAssignmentListBelongToStudentHandler : IRequestHandler<GetAssignmentListBelongToStudentQuery, List<AssignmentResponse>>
    {
        private readonly IRepositoryPort _repositoryPort;
        private readonly IMapper _mapper;

        public GetAssignmentListBelongToStudentHandler(IRepositoryPort _repositoryPort, IMapper _mapper)
        {
            this._repositoryPort = _repositoryPort;
            this._mapper = _mapper;
        }

        public async Task<List<AssignmentResponse>> Handle(GetAssignmentListBelongToStudentQuery request, CancellationToken cancellationToken)
        {
            var assignmentList = await _repositoryPort.GetAssignmentListWithStudentId(request.studentId);
            var response = _mapper.Map<List<AssignmentResponse>>(assignmentList);

            return response;
        }
    }
}
