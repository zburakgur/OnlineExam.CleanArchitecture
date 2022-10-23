using Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.Commands;
using OnlineExam.Application.Responses;
using OnlineExam.Domain.Entities;
using OnlineExam.Domain.UseCases;

namespace OnlineExam.Api.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IUserEnrollment userEnrollment;

        public LoginController(IUserEnrollment userEnrollment)
        {
            this.userEnrollment = userEnrollment;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<JsonResult> Login(CheckLoginCommand command)
        {
            ResponseData<bool> response = new ResponseData<bool>();

            try
            {
                Admin admin = command.ToModel<CheckLoginCommand, Admin>();
                bool result = await userEnrollment.CheckAdmin(admin);

                response.Success = true;
                response.Data = result;
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
