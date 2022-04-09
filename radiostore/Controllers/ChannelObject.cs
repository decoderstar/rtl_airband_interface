using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace radiostore.Controllers
{
    public class ChannelObject
    {
        public float Frequency { get; set; }

        public string Modulation { get; set; }

        public float SquelchLevel { get; set; }

        public float LowPass { get; set; }
        public float HighPass { get; set; }

        public List<FileChannelOutput> FileOutputList { get; set; } = new List<FileChannelOutput>();
        public List<MixerChannelOutput> MixerOutputList { get; set; } = new List<MixerChannelOutput>();

        public ChannelObject()
        {

        }

        public int GetOutputCount()
        {
            return FileOutputList.Count + MixerOutputList.Count();
        }
        public override string ToString()
        {
            return base.ToString();
        }

    }
}
