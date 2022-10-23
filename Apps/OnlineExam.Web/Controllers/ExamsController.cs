using Microsoft.AspNetCore.Mvc;

namespace OnlineExam.Web.Controllers
{
    public class ExamsController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
