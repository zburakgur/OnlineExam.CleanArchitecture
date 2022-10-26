using Infrastructure.Helpers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineExam.Web.Models;

namespace OnlineExam.Web.Controllers
{
    public class LoginController : Controller
    {


        private readonly HttpHelper httpHelper;

        public LoginController(HttpHelper httpHelper)
        {
            this.httpHelper = httpHelper;
        }

        [HttpPost]
        public async Task<JsonResult> CheckLogin(CheckLoginQuery login)
        {
            ResponseData<CheckLoginResponse> response = await httpHelper.Post<CheckLoginQuery, ResponseData<CheckLoginResponse>>($"Login/CheckLogin", login);
            if(response.Success && response.Data != default)
            {
                var sessionJSON = JsonConvert.SerializeObject(response.Data);
                HttpContext.Session.SetString("login", sessionJSON);
            }

            return Json(response);
        }
        
        public async Task<JsonResult> Logout()
        {
            HttpContext.Session.Clear();
            ResponseData<string> response = new ResponseData<string>();
            response.Success = true;
            response.Data = "OK";
            return Json(response);
        }

        public IActionResult Index()
        {
            var sessionJSON = HttpContext.Session.GetString("login");
            if(sessionJSON == null)
            {
                return View();
            }
            else
            {
                return new RedirectToRouteResult(
                    new RouteValueDictionary {
                                { "Controller", "Exams" },
                                { "Action", "Index" }
                    }
                );
            }
        }
    }
}
