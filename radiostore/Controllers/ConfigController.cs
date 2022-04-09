using System;
using Microsoft.AspNetCore.Mvc;
using radiostore.Config;

namespace radiostore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private readonly RadioStoreConfig _config;

        public ConfigController(RadioStoreConfig config)
        {
            _config = config;
        }
        
        [HttpGet]
        public void SaveConfig()
        {
            //RTLAirbandConfigManager.SaveFile("config.cfg");
            _config.SaveRadioStoreConfig();
            _config.ExportToAirbandConfigFile("config.cfg");
        }

        [HttpGet]
        public RadioStoreConfig GetConfig()
        {
            //Console.WriteLine("Test");
            //RTLAirbandConfigManager.LoadFile();
            //RTLAirbandConfigManager.LoadAlexFile();
            //return "Done";

            return _config;
        }
    }
}