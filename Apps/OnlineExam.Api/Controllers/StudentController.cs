using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.Commands;
using OnlineExam.Application.Queries;
using OnlineExam.Application.Responses;

namespace OnlineExam.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator _mediator)
        {
            this._mediator = _mediator;
        }

        [HttpGet]
        [Route("GetStudentList")]
        public async Task<JsonResult> GetStudentList()
        {
            ResponseData<List<StudentResponse>> response = new ResponseData<List<StudentResponse>>();

            try
            {
                var query = new GetStudentListQuery();
                response.Data = await _mediator.Send(query);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message.ToString();
            }

            return new JsonResult(response);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<JsonResult> Add(CreateStudentCommand command)
        {
            ResponseData<StudentResponse> response = new ResponseData<StudentResponse>();

            try
            {
                response.Success = true;
                response.Data = await _mediator.Send(command);
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message.ToString();
            }

            return new JsonResult(response);
        }
    }
}
