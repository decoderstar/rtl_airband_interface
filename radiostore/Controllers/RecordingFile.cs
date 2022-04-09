using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;

namespace radiostore.Controllers
{
    public class RecordingFile
    {
        private IWebHostEnvironment Environment;
        public RecordingFile()
        {
        }

        
        public List<Recording> GetAllRecordings(string Dir)
        {
            List<Recording> RecordList = new List<Recording>();
            string[] Files = Directory.GetFiles(Dir);

            foreach (string file in Files)
            {
                if (file.EndsWith(".wav"))
                {
                    string[ ] SplitOne = file.Split('/');
                    string BetterFile = Path.GetFileName(file);
                    RecordList.Add(new Recording(BetterFile, BetterFile, File.GetLastWriteTime(file)));
                }
            }
            return RecordList;
        }

    }
}
