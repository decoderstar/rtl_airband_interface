using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace radiostore.Controllers
{
    public class FileChannelOutput : ChannelOutputObject
    {
        [JsonProperty("directory")]
        public string Directory { get; set; } = "";
        
        [JsonProperty("file_name")]
        public string FileName = "";
        
        [JsonProperty("continuous")]
        public bool Continuous { get; set; }
        
        public FileChannelOutput()
        {
            OutputType = "file";
        }

        public override string ToString()
        {
            return " type = \"file\"; directory = \"" + Directory + "\"; filename_template = \"" + FileName + "\"; continuous  = " + Continuous.ToString().ToLower() + " ; ";
        }
    }
}
