using AutoMapper;
using Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.Commands;
using OnlineExam.Application.Responses;
using OnlineExam.Domain.Entities;
using OnlineExam.Domain.UseCases;

namespace OnlineExam.Api.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IUserEnrollment userEnrollment;

        public StudentController(IUserEnrollment userEnrollment)
        {
            this.userEnrollment = userEnrollment;
        }

        [HttpGet]
        [Route("GetStudentList")]
        public async Task<JsonResult> GetStudentList()
        {
            ResponseData<List<Student>> response = new ResponseData<List<Student>>();

            try
            {
                response.Data = await userEnrollment.ShowStudentList();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message.ToString();
            }

            return new JsonResult(response);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<JsonResult> Add(CreateStudentCommand command)
        {
            ResponseData<Student> response = new ResponseData<Student>();

            try
            {
                Student student = command.ToModel<CreateStudentCommand, Student>();
                student.Id = await userEnrollment.CreateStudent(student);

                response.Success = true;
                response.Data = student;
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message.ToString();
            }

            return new JsonResult(response);
        }
    }
}
