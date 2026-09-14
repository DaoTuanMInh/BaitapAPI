using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.IUser;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public readonly IStudentservice _studentservice;

        public StudentController(IStudentservice studentservice)
        {
            _studentservice = studentservice;
        }

        [HttpPost("getinterface")]
        public Studentcs infor2(Studentcs studentcs)
        {
            var s = _studentservice.informasion(studentcs);
            return s;
        }
    }
}
