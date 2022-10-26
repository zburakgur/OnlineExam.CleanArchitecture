using Infrastructure.Auth;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Api.Settings;
using OnlineExam.Application.Commands;

namespace OnlineExam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ApiSettings _apiSettings;

        public AuthController(IMediator _mediator, ApiSettings _apiSettings)
        {
            this._mediator = _mediator;
            this._apiSettings = _apiSettings;
        }

        [HttpPost]
        [Route("Token")]
        public async Task<TokenOutput> Token(TokenInput tokenInput)
        {
            var command = new CreateTokenCommand();
            command.Username = tokenInput.Username;
            command.Password = tokenInput.Password;
            command.ApiUsername = _apiSettings.Username;
            command.ApiPassword = _apiSettings.Password;

            return await _mediator.Send(command);
        }
    }
}
