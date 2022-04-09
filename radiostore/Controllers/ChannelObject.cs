using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace radiostore.Controllers
{
    public class ChannelObject
    {
        [JsonProperty("frequency")]
        public float Frequency { get; set; }

        [JsonProperty("modulation")]
        public string Modulation { get; set; }

        [JsonProperty("squelch_level")]
        public float SquelchLevel { get; set; }

        [JsonProperty("low_pass")]
        public float LowPass { get; set; }
        
        [JsonProperty("high_pass")]
        public float HighPass { get; set; }

        [JsonProperty("file_output_list")]
        public List<FileChannelOutput> FileOutputList { get; set; } = new();
        
        [JsonProperty("mixer_channel_output")]
        public List<MixerChannelOutput> MixerOutputList { get; set; } = new();

        public int GetOutputCount()
        {
            return FileOutputList.Count + MixerOutputList.Count;
        }
    }
}
