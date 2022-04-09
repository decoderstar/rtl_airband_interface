using radiostore.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace radiostore
{


    public struct RtlStructure
    {

    }


    public static class RTLAirbandConfigManager
    {


        public static string DeviceType { get; set; }

        public static float RFGain { get; set; }

        public static string Mode { get; set; }

        public static int DeviceIndex { get; set; }

        public static float CentreFrequency { get; set; }

        public static float Correction { get; set; }


        public static  List<object> Channels = new List<object>();



        public static string[] GetSplitByQuote(string Input)
        {
            return Input.Split("\"");
        }

        public static  void LoadFile()
        {
            if (!File.Exists("config.cfg"))
            {
                SaveFile("config.cfg");
            }


            string FileString = File.ReadAllText("config.cfg");
            Console.WriteLine("Reading all file lines");



            bool InANode = false;


            int OuterCount = 0;
            int InnerCount = 0;

            int Indexofit = FileString.IndexOf("channels");


            Dictionary<int, int> NodeDB = new Dictionary<int, int>();


            int tempnode = 0;
            for (int i =0; i < FileString.Length; i++)
            {

                char Character = FileString[i];

               // Console.WriteLine(Character);
              

                if (InANode)
                {
                    if (Character == '{')
                    {  
                        OuterCount++;
                    }

                    
                    if (Character == '}')
                    {
                        InnerCount++;
                    }

                    if (InnerCount == OuterCount)
                    {
                        Console.WriteLine("Node ended at character " + i);
                        InANode = false;
                        NodeDB.Add(tempnode, i);
                    }

                }

                if (!InANode)
                {

                    if (Character == '{')
                    {
                        Console.WriteLine("Node found at char " + i);
                        InANode = true;
                        OuterCount++;
                        tempnode = i;
                    }

                }


            }

            if (!InANode)
            {

            }
         
        }

        public static void SaveFile(string FilePath)
        {
            StringBuilder ConfigString = new StringBuilder();

            ConfigString.AppendLine("devices: ({   ");
            ConfigString.AppendLine("type = \"" + DeviceType + "\"");
            ConfigString.AppendLine("gain = " + RFGain.ToString());
            ConfigString.AppendLine("mode =  \"" + Mode + "\"");
            ConfigString.AppendLine("index = " + DeviceIndex);
            ConfigString.AppendLine("centerfreq = " + CentreFrequency.ToString());
            ConfigString.AppendLine("correction = " + Correction.ToString());

            if (Channels.Count > 0)
            {
                ConfigString.AppendLine("channels : (");

                foreach (ChannelObject Channel in Channels)
                {
                    ConfigString.AppendLine("{");
                    ConfigString.AppendLine("freq = " + Channel.Frequency + "; modulation = \"" + Channel.Modulation + "\"; squelch_snr_threshold = " + Channel.SquelchLevel + "; lowpass =  "
                        + Channel.LowPass + "; highpass = " + Channel.HighPass);

                    if (Channel.GetOutputCount() > 0)
                    {
                        ConfigString.AppendLine("outputs: (");

                        for (int i = 0; i < Channel.FileOutputList.Count; i++)
                        {
                            ConfigString.Append("{");
                            ConfigString.Append(Channel.FileOutputList[i].ToString());
                            string End = "},";
                            if (i == Channel.FileOutputList.Count && Channel.MixerOutputList.Count == 0)
                            {
                                End = "}";
                            }

                            ConfigString.AppendLine(End);
                        }

                        for (int i = 0; i < Channel.MixerOutputList.Count; i++)
                        {
                            ConfigString.Append("{");
                            ConfigString.Append(Channel.MixerOutputList[i].ToString());
                            string End = "},";
                            if (i == Channel.MixerOutputList.Count - 1)
                            {
                                End = "}";
                            }

                            ConfigString.AppendLine(End);
                        }

                        ConfigString.AppendLine(");");
                    }

                    ConfigString.AppendLine("}");
                }

                ConfigString.AppendLine(");");

            }

            ConfigString.AppendLine("} )");


            File.WriteAllText(FilePath, ConfigString.ToString());

        }


    }
}
