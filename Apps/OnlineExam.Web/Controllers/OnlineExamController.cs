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

        public async Task<IActionResult> Index(int assignmentId)
        {
            var response = await httpHelper.GetAsync<ResponseData<CheckAssignmentResponse>>($"Assignment/CheckAssignment?assignmentId={assignmentId}");
            if (response.Data.Status == Enums.AssignmentStatus.OK)
            {
                ViewBag.Title = "";
                ViewBag.Data = response.Data;
                return View();
            }
            else
            {
                return View();
            }
        }
    }
}
