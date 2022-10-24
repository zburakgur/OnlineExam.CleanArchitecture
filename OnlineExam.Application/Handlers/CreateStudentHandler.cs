using AutoMapper;
using MediatR;
using OnlineExam.Application.Commands;
using OnlineExam.Application.Responses;
using OnlineExam.Domain.Entities;
using OnlineExam.Domain.Ports;

namespace OnlineExam.Application.Handlers
{
    public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, StudentResponse>
    {
        private readonly IRepositoryPort _repositoryPort;
        private readonly IMapper _mapper;

        public CreateStudentHandler(IRepositoryPort _repositoryPort, IMapper _mapper)
        {
            this._repositoryPort = _repositoryPort;
            this._mapper = _mapper;
        }

        public async Task<StudentResponse> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            Student student = _mapper.Map<Student>(request);
            student.Id = await _repositoryPort.CreateStudent(student);

            var response = _mapper.Map<StudentResponse>(student);
            return response;
        }
    }
}
