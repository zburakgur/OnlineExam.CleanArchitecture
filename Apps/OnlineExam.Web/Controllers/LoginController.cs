using Microsoft.AspNetCore.Mvc;

namespace OnlineExam.Web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
