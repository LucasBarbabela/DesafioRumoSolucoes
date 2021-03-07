using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using DesafioRumoSolucoes.Configurations;
using DesafioRumoSolucoes.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DesafioRumoSolucoes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private CarDealershipContext _contexto;
        public WeatherForecastController(CarDealershipContext contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public string Get()
        {
            return "teste";
        }
    }
}
