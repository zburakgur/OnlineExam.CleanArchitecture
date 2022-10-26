using AutoMapper;
using Infrastructure.Auth;
using Infrastructure.Jwt;
using MediatR;
using OnlineExam.Application.Commands;

namespace OnlineExam.Application.Handlers
{
    public class CreateTokenHandler : IRequestHandler<CreateTokenCommand, TokenOutput>
    {
        private readonly IMapper _mapper;
        private readonly IJwtHandler<string> jwtHandler;

        public CreateTokenHandler(IMapper _mapper, IJwtHandler<string> jwtHandler)
        {
            this._mapper = _mapper;
            this.jwtHandler = jwtHandler;
        }

        public async Task<TokenOutput> Handle(CreateTokenCommand request, CancellationToken cancellationToken)
        {
            if(request.Username == request.ApiUsername & request.Password == request.ApiPassword)
            {
                return _mapper.Map<TokenOutput>(jwtHandler.Create(request.Username));
            }

            return new TokenOutput();
        }
    }
}
