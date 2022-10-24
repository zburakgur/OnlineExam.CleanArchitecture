using Infrastructure.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace OnlineExam.Web.Controllers
{
    public class OnlineExamController : Controller
    {
        private readonly HttpHelper httpHelper;

        public OnlineExamController(HttpHelper httpHelper)
        {
            this.httpHelper = httpHelper;
        }

        public IActionResult Index(int assignmentId)
        {
            return View();
        }
    }
}
