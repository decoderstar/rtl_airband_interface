using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using radiostore.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace radiostore.ClientApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordingController : ControllerBase
    {
        private readonly IHostingEnvironment HostEnvironment;

        private readonly ILogger<RecordingController> _logger;

        public RecordingController(ILogger<RecordingController> logger, IHostingEnvironment environment)
        {
            this.HostEnvironment = environment;
            _logger = logger;
        }



        [HttpGet]
        public IEnumerable<Recording> Get()
        {
            RecordingFile Records = new RecordingFile();
            return Records.GetAllRecordings(HostEnvironment.WebRootPath).ToArray();
        }


        [Route("recording/{id?}")]
        public string Index(int? id)
        {
            return "hi " + id;
        }


    }


    /*
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessTest : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            RtlManager Proctest = new RtlManager();
            return Proctest.Start();
        }
    }
    */
}
