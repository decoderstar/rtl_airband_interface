// using radiostore.Controllers;
// using System;
// using System.Collections.Generic;
// using System.IO;
// using System.Linq;
// using System.Runtime.InteropServices;
// using System.Text;
// using System.Threading.Tasks;
// using Newtonsoft.Json;
//
// namespace radiostore
// {
//
//
//     public struct RtlStructure
//     {
//
//     }
//
//
//     public static class RTLAirbandConfigManager
//     {
//         /*public static readonly char[] validNumbers =
//         {
//             '0',
//             '1',
//             '2',
//             '3',
//             '4',
//             '5',
//             '6',
//             '7',
//             '8',
//             '9'
//         };*/
//
//         public static string DeviceType { get; set; }
//
//         public static float RFGain { get; set; }
//
//         public static string Mode { get; set; }
//
//         public static int DeviceIndex { get; set; }
//
//         public static float CentreFrequency { get; set; }
//
//         public static float Correction { get; set; }
//
//
//         public static List<ChannelObject> Channels = new();
//
//
//
//         public static string[] GetSplitByQuote(string Input)
//         {
//             return Input.Split("\"");
//         }
//
//         /*public static void LoadAlexFile()
//         {
//             if (!File.Exists("config.cfg"))
//             {
//                 SaveFile("config.cfg");
//             }
//             
//             string cfg = File.ReadAllText("config.cfg");
//             Console.WriteLine("Reading all file lines");
//
//             int charPos = 0;
//
//             try
//             {
//                 while (true)
//                 {
//                     //Handles # comments
//                     if (cfg[charPos] == '#')
//                     {
//                         do
//                         {
//                             charPos++;
//                         } while (cfg[charPos] != '\r' && cfg[charPos] != '\n');
//
//                         if (cfg[charPos + 1] == '\n') charPos++;
//                     }
//
//                     //Handles // comments
//                     if (cfg[charPos] == '/' && cfg[charPos + 1] == '/')
//                     {
//                         charPos++;
//
//                         do
//                         {
//                             charPos++;
//                         } while (cfg[charPos] != '\r' && cfg[charPos] != '\n');
//
//                         if (cfg[charPos + 1] == '\n') charPos++;
//                     }
//
//                     //Handles / ** / comments
//                     if (cfg[charPos] == '/' && cfg[charPos + 1] == '*')
//                     {
//                         charPos++;
//
//                         do
//                         {
//                             charPos++;
//                         } while (cfg[charPos] != '*' && cfg[charPos + 1] != '/');
//
//                         charPos++;
//                     }
//
//                     //Skip whitespace
//                     if (cfg[charPos] is ' ' or '\t' or '\r' or '\n')
//                     {
//                         charPos++;
//                         continue;
//                     }
//
//                     //Start reading variable name
//                     while (true)
//                     {
//                         string variableName = "";
//                         
//                         //Skip whitespace
//                         if (cfg[charPos] is ' ' or '\t' or '\r' or '\n')
//                         {
//                             charPos++;
//                             continue;
//                         }
//
//                         //Capture end of variable name
//                         if (cfg[charPos] is ':' or '=')
//                         {
//                             charPos++;
//
//                             while (true)
//                             {
//                                 //Skip whitespace
//                                 if (cfg[charPos] is ' ' or '\t' or '\r' or '\n')
//                                 {
//                                     charPos++;
//                                     continue;
//                                 }   
//                                 
//                                 //Start interpreting variable contents
//                                 if (cfg[charPos] == '(')
//                                 {
//                                     //Start interpreting list
//                                 }
//
//                                 if (cfg[charPos] == '{')
//                                 {
//                                     //Start interpreting group
//                                 }
//
//                                 if (cfg[charPos] == '"')
//                                 {
//                                     //Start interpreting string
//                                 }
//                                 
//                                 if (cfg[charPos] == '-' || int.TryParse(cfg[charPos].ToString(), out int _))
//                                 {
//                                     //Start interpreting number
//                                 }
//                             }
//
//                             break; //Break out of variable interpretation to move on to next variable
//                         }
//
//                         //Capture variable character
//                         variableName += cfg[charPos];
//                         charPos++;
//                     }
//                     
//                     
//                 }
//             }
//             catch (IndexOutOfRangeException)
//             {
//                 throw new Exception($"Failed to parse config file near character {charPos}");
//             }
//         }*/
//
//         /*public static  void LoadFile()
//         {
//             if (!File.Exists("config.cfg"))
//             {
//                 SaveFile("config.cfg");
//             }
//
//
//             string FileString = File.ReadAllText("config.cfg");
//             Console.WriteLine("Reading all file lines");
//
//
//
//             bool InANode = false;
//
//
//             int OuterCount = 0;
//             int InnerCount = 0;
//
//             int Indexofit = FileString.IndexOf("channels");
//
//
//             Dictionary<int, int> NodeDB = new Dictionary<int, int>();
//
//
//             int tempnode = 0;
//             for (int i =0; i < FileString.Length; i++)
//             {
//
//                 char Character = FileString[i];
//
//                // Console.WriteLine(Character);
//               
//
//                 if (InANode)
//                 {
//                     if (Character == '{')
//                     {  
//                         OuterCount++;
//                     }
//
//                     
//                     if (Character == '}')
//                     {
//                         InnerCount++;
//                     }
//
//                     if (InnerCount == OuterCount)
//                     {
//                         Console.WriteLine("Node ended at character " + i);
//                         InANode = false;
//                         NodeDB.Add(tempnode, i);
//                     }
//
//                 }
//
//                 if (!InANode)
//                 {
//
//                     if (Character == '{')
//                     {
//                         Console.WriteLine("Node found at char " + i);
//                         InANode = true;
//                         OuterCount++;
//                         tempnode = i;
//                     }
//
//                 }
//
//
//             }
//
//             if (!InANode)
//             {
//
//             }
//          
//         }*/
//
//         public static void SaveFile(string FilePath)
//         {
//             StringBuilder ConfigString = new StringBuilder();
//
//             ConfigString.AppendLine("devices: ({   ");
//             ConfigString.AppendLine("type = \"" + DeviceType + "\"");
//             ConfigString.AppendLine("gain = " + RFGain);
//             ConfigString.AppendLine("mode =  \"" + Mode + "\"");
//             ConfigString.AppendLine("index = " + DeviceIndex);
//             ConfigString.AppendLine("centerfreq = " + CentreFrequency);
//             ConfigString.AppendLine("correction = " + Correction);
//
//             if (Channels.Count > 0)
//             {
//                 ConfigString.AppendLine("channels : (");
//
//                 foreach (ChannelObject Channel in Channels)
//                 {
//                     ConfigString.AppendLine("{");
//                     ConfigString.AppendLine("freq = " + Channel.Frequency + "; modulation = \"" + Channel.Modulation + "\"; squelch_snr_threshold = " + Channel.SquelchLevel + "; lowpass =  "
//                         + Channel.LowPass + "; highpass = " + Channel.HighPass);
//
//                     if (Channel.GetOutputCount() > 0)
//                     {
//                         ConfigString.AppendLine("outputs: (");
//
//                         for (int i = 0; i < Channel.FileOutputList.Count; i++)
//                         {
//                             ConfigString.Append("{");
//                             ConfigString.Append(Channel.FileOutputList[i].ToString());
//                             string End = "},";
//                             if (i == Channel.FileOutputList.Count && Channel.MixerOutputList.Count == 0)
//                             {
//                                 End = "}";
//                             }
//
//                             ConfigString.AppendLine(End);
//                         }
//
//                         for (int i = 0; i < Channel.MixerOutputList.Count; i++)
//                         {
//                             ConfigString.Append("{");
//                             ConfigString.Append(Channel.MixerOutputList[i].ToString());
//                             string End = "},";
//                             if (i == Channel.MixerOutputList.Count - 1)
//                             {
//                                 End = "}";
//                             }
//
//                             ConfigString.AppendLine(End);
//                         }
//
//                         ConfigString.AppendLine(");");
//                     }
//
//                     ConfigString.AppendLine("}");
//                 }
//
//                 ConfigString.AppendLine(");");
//
//             }
//
//             ConfigString.AppendLine("} )");
//
//
//             File.WriteAllText(FilePath, ConfigString.ToString());
//
//         }
//
//
//     }
// }
