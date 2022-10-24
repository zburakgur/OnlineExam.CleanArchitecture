using AutoMapper;
using MediatR;
using OnlineExam.Application.Queries;
using OnlineExam.Application.Responses;
using OnlineExam.Domain.Entities;
using OnlineExam.Domain.Ports;

namespace OnlineExam.Application.Handlers
{
    public class CheckLoginHandler : IRequestHandler<CheckLoginQuery, CheckLoginResponse>
    {
        private readonly IRepositoryPort _repositoryPort;
        private readonly IMapper _mapper;

        public CheckLoginHandler(IRepositoryPort _repositoryPort, IMapper _mapper)
        {
            this._repositoryPort = _repositoryPort;
            this._mapper = _mapper;
        }

        public async Task<CheckLoginResponse> Handle(CheckLoginQuery request, CancellationToken cancellationToken)
        {
            Admin admin = _mapper.Map<Admin>(request);
            var tmp = _repositoryPort.CheckAdmin(admin);

            var response = _mapper.Map<CheckLoginResponse>(tmp);
            return response;
        }
    }
}
