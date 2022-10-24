using Infrastructure.Helpers;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Web.Models;

namespace OnlineExam.Web.Controllers
{
    public class StudentsController : Controller
    {
        private readonly HttpHelper httpHelper;

        public StudentsController(HttpHelper httpHelper)
        {
            this.httpHelper = httpHelper;
        }

        [HttpPost]
        public async Task<JsonResult> Add(CreateStudentCommand student)
        {
            return Json(await httpHelper.Post<CreateStudentCommand, ResponseData<StudentResponse>>($"Student/Add", student));
        }

        public async Task<JsonResult> GetStudentList()
        {            
            return Json(await httpHelper.GetAsync<ResponseData<List<StudentResponse>>>($"Student/GetStudentList"));
        }

        public async Task<JsonResult> GetAssignmentList(int studentId)
        {
            return Json(await httpHelper.GetAsync<ResponseData<List<AssignmentResponse>>>($"Assignment/GetAssignmentList?studentId={studentId}"));
        }

        public async Task<JsonResult> Assign(CreateAssignmentCommand assignment)
        {
            return Json(await httpHelper.Post<CreateAssignmentCommand, ResponseData<AssignmentResponse>>($"Assignment/Assign", assignment));
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
