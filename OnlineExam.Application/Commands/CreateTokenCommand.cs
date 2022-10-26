using Infrastructure.Auth;
using MediatR;

namespace OnlineExam.Application.Commands
{
    public class CreateTokenCommand : IRequest<TokenOutput>
    {
        public string Password { get; set; }

        public string Username { get; set; }

        public string ApiUsername { get; set; }

        public string ApiPassword { get; set; }
    }
}
