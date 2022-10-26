using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using OnlineExam.Web.Models;

namespace OnlineExam.Web.Controllers
{    
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var sessionJSON = HttpContext.Session.GetString("login");
            if (sessionJSON == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {
                                { "Controller", "Login" },
                                { "Action", "Index" }
                    }
                );
            }
        }
    }
}


