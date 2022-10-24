using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.Commands;
using OnlineExam.Application.Queries;
using OnlineExam.Application.Responses;

namespace OnlineExam.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssignmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AssignmentController(IMediator _mediator)
        {
            this._mediator = _mediator;
        }

        [HttpGet]
        [Route("GetAssignmentList")]
        public async Task<JsonResult> GetAssignmentList(int studentId)
        {
            ResponseData<List<AssignmentResponse>> response = new ResponseData<List<AssignmentResponse>>();

            try
            {
                var query = new GetAssignmentListBelongToStudentQuery();
                query.studentId = studentId;

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
        [Route("Assign")]
        public async Task<JsonResult> Assign(CreateAssignmentCommand command)
        {
            ResponseData<AssignmentResponse> response = new ResponseData<AssignmentResponse>();

            try
            {
                response.Data = await _mediator.Send(command);
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
