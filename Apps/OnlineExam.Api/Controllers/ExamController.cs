using Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Api.Settings;
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
        private readonly QuestionsPath _questPath;

        public ExamController(IExamEnrollment examEnrollment, QuestionsPath _questPath)
        {
            this.examEnrollment = examEnrollment;
            this._questPath = _questPath;
        }

        [HttpGet]
        [Route("GetQuestionList")]
        public async Task<JsonResult> GetQuestionList(string examCode)
        {
            ResponseData<List<Question>> response = new ResponseData<List<Question>>();

            try
            {                
                response.Success = true;
                response.Data = await examEnrollment.ShowQuestionListBelongToExam(examCode, _questPath.Path);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message.ToString();
            }

            return new JsonResult(response);
        }

        [HttpGet]
        [Route("GetExamList")]
        public async Task<JsonResult> GetExamList()
        {
            ResponseData<List<Exam>> response = new ResponseData<List<Exam>>();

            try
            {
                response.Success = true;
                response.Data = await examEnrollment.ShowExamList();
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
