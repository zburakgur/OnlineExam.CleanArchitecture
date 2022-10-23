using Infrastructure.Helpers;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Domain.Entities;
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
        public async Task<JsonResult> Add(Student student)
        {
            return Json(await httpHelper.Post<Student, ResponseData<Student>>($"Student/Add", student));
        }

        public async Task<JsonResult> GetStudentList()
        {            
            return Json(await httpHelper.GetAsync<ResponseData<List<Student>>>($"Student/GetStudentList"));
        }

        public async Task<JsonResult> GetAssignmentList(int studentId)
        {
            return Json(await httpHelper.GetAsync<ResponseData<List<Assignment>>>($"Assignment/GetAssignmentList?studentId={studentId}"));
        }

        public async Task<JsonResult> Assign(Assignment assignment)
        {
            return Json(await httpHelper.Post<Assignment, ResponseData<Assignment>>($"Assignment/Assign", assignment));
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
