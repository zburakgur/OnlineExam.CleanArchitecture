using Infrastructure.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineExam.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TestController : Controller
    {

        [HttpGet]
        [Route("Test")]
        public TokenOutput Test()
        {
            return new TokenOutput() { Token = "asdasdşaskdşsakd"};
        }
    }
}
