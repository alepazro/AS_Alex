using Microservicios1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;

namespace Microservicios.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonaController : ControllerBase
    {
        private static readonly Persona[] Summaries = new[]
        {
            new Persona {nombre="Alexander"},
            new Persona{nombre="David"},
            new Persona{nombre="Juan David"},
            new Persona{nombre="Emilio"}
        };

        private readonly ILogger<PersonaController> _logger;

        public PersonaController(ILogger<PersonaController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetNombres")]
        public ICollection<Persona> Get()
        {
            return Summaries.ToList();
        }
    }
}
