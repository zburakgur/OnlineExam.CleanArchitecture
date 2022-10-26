using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.Queries;
using OnlineExam.Application.Responses;

namespace OnlineExam.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator _mediator)
        {
            this._mediator = _mediator;
        }

        [HttpPost]
        [Route("CheckLogin")]
        public async Task<JsonResult> CheckLogin(CheckLoginQuery query)
        {
            ResponseData<CheckLoginResponse> response = new ResponseData<CheckLoginResponse>();

            try
            {
                response.Data =  await _mediator.Send(query);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message.ToString();
            }

            return new JsonResult(response);
        }
    }
}
