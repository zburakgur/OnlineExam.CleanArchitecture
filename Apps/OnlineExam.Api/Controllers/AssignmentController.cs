using Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.Commands;
using OnlineExam.Application.Responses;
using OnlineExam.Domain.Entities;
using OnlineExam.Domain.UseCases;

namespace OnlineExam.Api.Controllers
{
    [Route("api/[controller]")]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignExamToStudent assignExamToStudent;

        public AssignmentController(IAssignExamToStudent assignExamToStudent)
        {
            this.assignExamToStudent = assignExamToStudent;
        }

        [HttpPost]
        [Route("Assign")]
        public async Task<JsonResult> Assign(CreateAssignmentCommand command)
        {
            ResponseData<Assignment> response = new ResponseData<Assignment>();

            try
            {
                Assignment assignment = command.ToModel<CreateAssignmentCommand, Assignment>();
                assignment.Id = await assignExamToStudent.CreateAssignment(assignment);

                response.Success = true;
                response.Data = assignment;
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
