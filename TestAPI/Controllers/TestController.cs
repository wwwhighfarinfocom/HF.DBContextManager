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
    public class TestController : ControllerBase
    {

        private DapperClient mysql;


        public TestController(ILogger<TestController> logger, IDapperClientFactory dapperFactory)
        {
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
