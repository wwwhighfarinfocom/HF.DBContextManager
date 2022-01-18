using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HF.DBContextManager;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private DapperClient mysql;

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IDapperClientFactory dapperFactory)
        {
            _logger = logger;
            mysql = dapperFactory.GetClient("MySql");
        }




        [HttpGet]
        public Object GetUserInfo()
        {
            var result = mysql.Query<dynamic>(@"select * from itpuxdb.bm");
            return Ok(result);
        }
    }
}
