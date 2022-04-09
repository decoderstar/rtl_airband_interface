using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace radiostore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessController : ControllerBase
    {
        private readonly ILogger<ProcessController> _logger;

        public ProcessController(ILogger<ProcessController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            return "hi";
        }

        [Route("{id?}")]
        public string Index(int? id)
        {
            return "hi " + id;
        }

        [Route("getstate")]
        public bool GetState()
        {
            return (Process.GetProcessesByName("calculator").Length > 0);
        }
    }
}
