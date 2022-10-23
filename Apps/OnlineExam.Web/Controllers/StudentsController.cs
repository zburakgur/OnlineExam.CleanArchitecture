﻿using Infrastructure.Helpers;
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

        public async Task<JsonResult> GetStudentList()
        {            
            return Json(await httpHelper.GetAsync<ResponseData<List<Student>>>($"Student/GetStudentList"));
        }

        public async Task<JsonResult> GetAssignmentList(int studentId)
        {
            return Json(await httpHelper.GetAsync<ResponseData<List<AssignmentBelongtoUser>>>($"Assignment/GetAssignmentList?studentId={studentId}"));
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
