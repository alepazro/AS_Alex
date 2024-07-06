using AS_CAPAS.Controller;
using AS_CAPAS.Modelo;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id}")]
        public User Get(string id)
        {
            UserController userController = new UserController();
            User usuario= new User();
            User usuario2 = new User();
            usuario.id = "1";
            usuario.name = "Juan";
            usuario.email = "juan@gmail.com";
            usuario2.id = "2";
            usuario2.name = "Juan2";
            usuario2.email = "juan2@gmail.com";

            userController.saveUser(usuario);
            userController.saveUser(usuario2);

            var user2=userController.getUserById(id);
            return user2;
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            //    TemperatureC = Random.Shared.Next(-20, 55),
            //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            //})
            //.ToArray();
        }
    }
}
