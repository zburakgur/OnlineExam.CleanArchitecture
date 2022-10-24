using MediatR;
using OnlineExam.Application.Responses;

namespace OnlineExam.Application.Queries
{
    public class CheckLoginQuery : IRequest<CheckLoginResponse>
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
