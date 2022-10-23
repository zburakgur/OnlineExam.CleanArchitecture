using Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.Commands;
using OnlineExam.Application.Responses;
using OnlineExam.Domain.Entities;
using OnlineExam.Domain.UseCases;

namespace OnlineExam.Api.Controllers
{
    [Route("api/[controller]")]
    public class ExamController : ControllerBase
    {
        private readonly IExamEnrollment examEnrollment;

        public ExamController(IExamEnrollment examEnrollment)
        {
            this.examEnrollment = examEnrollment;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<JsonResult> Add(CreateExamCommand command)
        {
            ResponseData<Exam> response = new ResponseData<Exam>();

            try
            {
                Exam exam = command.ToModel<CreateExamCommand, Exam>();
                exam.Id = await examEnrollment.CreateExam(exam);

                response.Success = true;
                response.Data = exam;
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
