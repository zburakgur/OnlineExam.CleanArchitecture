using Infrastructure.Helpers;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Web.Models;

namespace OnlineExam.Web.Controllers
{
    public class OnlineExamController : Controller
    {
        private readonly HttpHelper httpHelper;

        public OnlineExamController(HttpHelper httpHelper)
        {
            this.httpHelper = httpHelper;
        }

        [HttpPost]
        public async Task<JsonResult> CompleteExam(CompleteExamInput input)
        {
            return Json(await httpHelper.Post<CompleteExamInput, ResponseData<CompleteExamResponse>>($"Exam/CompleteExam", input));
        }

        public async Task<IActionResult> Index(int assignmentId)
        {
            var response = await httpHelper.GetAsync<ResponseData<CheckAssignmentResponse>>($"Assignment/CheckAssignment?assignmentId={assignmentId}");
            ViewBag.Data = response.Data;
            return View();
        }
    }
}
