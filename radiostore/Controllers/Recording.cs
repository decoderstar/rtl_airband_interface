using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace radiostore.Controllers
{
    public class Recording
    {

        public string RecordingName { get; set; }
        public string RecordingPath { get; set; }
        public DateTime RecordingDate { get; set; }
        public Recording()
        {

        }

        public Recording(string name, string path, DateTime date)
        {
            this.RecordingName = name;
            this.RecordingPath = path;
            this.RecordingDate = date;
        }
    }
}
