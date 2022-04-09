using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace radiostore.Controllers
{
    public class FileChannelOutput : ChannelOutputObject
    {
        public string Directory { get; set; } = "";
        public string FileName = "";
        public bool Continuous { get; set; } = false;
        public FileChannelOutput()
        {
            this.OutputType = "file";
        }

        public override string ToString()
        {
            return " type = \"file\"; directory = \"" + Directory + "\"; filename_template = \"" + FileName + "\"; continuous  = " + Continuous.ToString().ToLower() + " ; ";
        }
        


    }
}
