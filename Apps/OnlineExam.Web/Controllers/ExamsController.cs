using Infrastructure.Helpers;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Domain.Entities;
using OnlineExam.Web.Models;

namespace OnlineExam.Web.Controllers
{
    public class ExamsController : Controller
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
            return Json(await httpHelper.GetAsync<ResponseData<List<Exam>>>($"Exam/GetExamList"));
        }

        public async Task<JsonResult> GetQuestionList(string examCode)
        {            
            return Json(await httpHelper.GetAsync<ResponseData<List<Question>>>($"Exam/GetQuestionList?examCode={examCode}"));
        }
    }
}
