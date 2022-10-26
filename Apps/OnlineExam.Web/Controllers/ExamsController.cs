using Infrastructure.Helpers;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Web.Models;

namespace OnlineExam.Web.Controllers
{
    public class ExamsController : BaseController
    {
        private readonly HttpHelper httpHelper;

        public ExamsController(HttpHelper httpHelper)
        {
            this.httpHelper = httpHelper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetExamList()
        {            
            return Json(await httpHelper.GetAsync<ResponseData<List<ExamResponse>>>($"Exam/GetExamList"));
        }

        public async Task<JsonResult> GetExamListAvailableForStudent(int studentId)
        {
            return Json(await httpHelper.GetAsync<ResponseData<List<ExamResponse>>>($"Exam/GetExamListAvailableForStudent?studentId={studentId}"));
        }

        public async Task<JsonResult> GetQuestionList(string examCode)
        {            
            return Json(await httpHelper.GetAsync<ResponseData<List<QuestionResponse>>>($"Exam/GetQuestionList?examCode={examCode}"));
        }
    }
}
