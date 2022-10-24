using AutoMapper;
using MediatR;
using OnlineExam.Application.Commands;
using OnlineExam.Application.Responses;
using OnlineExam.Domain.Entities;
using OnlineExam.Domain.Ports;

namespace OnlineExam.Application.Handlers
{
    public class CreateAssignmentHandler : IRequestHandler<CreateAssignmentCommand, AssignmentResponse>
    {
        private readonly IRepositoryPort _repositoryPort;
        private readonly IMapper _mapper;

        public CreateAssignmentHandler(IRepositoryPort _repositoryPort, IMapper _mapper)
        {
            this._repositoryPort = _repositoryPort;
            this._mapper = _mapper;
        }

        public async Task<AssignmentResponse> Handle(CreateAssignmentCommand request, CancellationToken cancellationToken)
        {
            var assignment = _mapper.Map<Assignment>(request);
            assignment.Score = 0;
            assignment.Deadline = DateTime.Now.AddDays(1);
            assignment.IsCompleted = false;

            assignment.Id = await _repositoryPort.CreateAssignment(assignment);

            var response = _mapper.Map<AssignmentResponse>(assignment);
            return response;
        }
    }
}
