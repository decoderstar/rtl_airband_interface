using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace radiostore.Controllers
{
    public class ChannelOutputObject
    {
        [JsonProperty("output_type")]
        public string OutputType { get; set; }
    }
}
