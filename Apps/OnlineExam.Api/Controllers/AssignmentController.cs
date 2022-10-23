using Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.Commands;
using OnlineExam.Application.Responses;
using OnlineExam.Application.UseCases;
using OnlineExam.Domain.Entities;
using OnlineExam.Domain.UseCases;
using System.Collections.Generic;

namespace OnlineExam.Api.Controllers
{
    [Route("api/[controller]")]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignExamToStudent assignExamToStudent;
        private readonly IExamEnrollment examEnrollment;

        public AssignmentController(IAssignExamToStudent assignExamToStudent, 
                                    IExamEnrollment examEnrollment)
        {
            this.assignExamToStudent = assignExamToStudent;
            this.examEnrollment = examEnrollment;
        }

        [HttpGet]
        [Route("GetAssignmentList")]
        public async Task<JsonResult> GetAssignmentList(int studentId)
        {
            ResponseData<List<AssignmentBelongtoUser>> response = new ResponseData<List<AssignmentBelongtoUser>>();

            try
            {
                List<Assignment> assignments = await assignExamToStudent.ShowAssignmentBelongToStudent(studentId);
                response.Data = new List<AssignmentBelongtoUser>();
                
                foreach(Assignment assignment in assignments)
                {
                    AssignmentBelongtoUser assignmentBelongtoUser = assignment.ToModel<Assignment, AssignmentBelongtoUser>();
                    Exam exam = await examEnrollment.GetExamWithId(assignmentBelongtoUser.ExamId);
                    assignmentBelongtoUser.Code = exam.Code;
                    assignmentBelongtoUser.Header = exam.Header;
                    response.Data.Add(assignmentBelongtoUser);
                }
                
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
        [Route("Assign")]
        public async Task<JsonResult> Assign(CreateAssignmentCommand command)
        {
            ResponseData<Assignment> response = new ResponseData<Assignment>();

            try
            {
                Assignment assignment = command.ToModel<CreateAssignmentCommand, Assignment>();
                assignment.Id = await assignExamToStudent.CreateAssignment(assignment);

                response.Success = true;
                response.Data = assignment;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message.ToString();
            }

            return new JsonResult(response);
        }
    }
}
