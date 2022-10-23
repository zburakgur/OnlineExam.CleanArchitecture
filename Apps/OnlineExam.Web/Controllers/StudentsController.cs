using Microsoft.AspNetCore.Mvc;

namespace OnlineExam.Web.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
