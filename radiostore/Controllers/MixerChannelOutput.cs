using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace radiostore.Controllers
{
    public class MixerChannelOutput : ChannelOutputObject
    {
        public string MixerName { get; set; }
        public float Balance { get; set; }
        public MixerChannelOutput()
        {
            this.OutputType = "file";
        }

        public override string ToString()
        {
            return "  type = \"mixer\"; name = \"" + MixerName + "\"; balance = " + Balance.ToString("0.0") + "; ";
        }
    }
}
