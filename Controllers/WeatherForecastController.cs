using Microsoft.AspNetCore.Mvc;
using WebApplication1.IUser;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        public readonly IUserService _userService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        //[HttpGet(Name = "GetWeatherForecast")]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
        //[HttpGet("getuser")]
        //public IActionResult Test(string name)
        //{
        //    var a = _userService.user(name);
        //      return Ok(a);
        //}
        //[HttpGet("gettenvatuoi")]
        //public IActionResult TenVaTuoi(string name,int year)
        //{
        //    var b = _userService.yearold(name, year);
        //    return Ok(b);
        //}
        [HttpPost("infor")]
        public IActionResult Infor(User user)
        {
            var c = _userService.infor(user);
            return Ok(c);
        }
    }
}
