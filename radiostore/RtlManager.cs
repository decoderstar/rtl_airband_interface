using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace radiostore
{
    public class RtlManager
    {
        private  const string ProcessName = "rtl_airband";

        private  Process RtlProcess { get; set; }

        private string TestStr  { get; set; } = "";
        public RtlManager()
        {
            RtlProcess =  new Process();
        }

        public string Start()
        {
            RtlProcess.StartInfo.FileName = ProcessName;

            RtlProcess.StartInfo.Arguments = "-h";
            RtlProcess.StartInfo.UseShellExecute = false;
            RtlProcess.StartInfo.RedirectStandardOutput = true;
            RtlProcess.StartInfo.RedirectStandardError = true;
            RtlProcess.OutputDataReceived += OutputHandler;
            RtlProcess.Start();
            RtlProcess.BeginOutputReadLine();
            Console.WriteLine("Its running");
            return "";
        }

         void OutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            Console.WriteLine(outLine.Data);
            Console.WriteLine("Received data");
           // TestStr = TestStr + outLine.Data.ToString();
        }



        public void Stop()
        {
            RtlProcess.Kill();
        }







    }
}
