using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Api.Settings;
using OnlineExam.Application.Queries;
using OnlineExam.Application.Responses;

namespace OnlineExam.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly QuestionsPath _questPath;

        public ExamController(IMediator _mediator, QuestionsPath _questPath)
        {
            this._mediator = _mediator;
            this._questPath = _questPath;
        }

        [HttpGet]
        [Route("GetQuestionList")]
        public async Task<JsonResult> GetQuestionList(string examCode)
        {
            ResponseData<List<QuestionResponse>> response = new ResponseData<List<QuestionResponse>>();

            try
            {
                var query = new GetQuestionListBelongToExamQuery();
                query.ExamCode = examCode;
                query.QuestionsPath = _questPath.Path;

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

        [HttpGet]
        [Route("GetExamList")]
        public async Task<JsonResult> GetExamList()
        {
            ResponseData<List<ExamResponse>> response = new ResponseData<List<ExamResponse>>();

            try
            {
                var query = new GetExamListQuery();
                query.Path = _questPath.Path;

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

        [HttpGet]
        [Route("GetExamListAvailableForStudent")]
        public async Task<JsonResult> GetExamListAvailableForStudent(int studentId)
        {
            ResponseData<List<ExamResponse>> response = new ResponseData<List<ExamResponse>>();

            try
            {
                var query = new GetExamListAvailableForStudentQuery();
                query.StudentId = studentId;
                query.Path = _questPath.Path;

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
    }
}
