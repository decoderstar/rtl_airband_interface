using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace radiostore.Controllers
{
    public class MixerChannelOutput : ChannelOutputObject
    {
        [JsonProperty("mixer_name")]
        public string MixerName { get; set; }
        
        [JsonProperty("balance")]
        public float Balance { get; set; }
        
        public MixerChannelOutput()
        {
            OutputType = "file";
        }

        public override string ToString()
        {
            return "  type = \"mixer\"; name = \"" + MixerName + "\"; balance = " + Balance.ToString("0.0") + "; ";
        }
    }
}
