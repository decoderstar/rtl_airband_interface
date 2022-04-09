using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using radiostore.Controllers;

namespace radiostore.Config
{
    public class RadioStoreConfig
    {
        [JsonIgnore]
        public string ConfigSavePath { get; set; }
        
        [JsonProperty("device_type")]
        public string DeviceType { get; set; }

        [JsonProperty("rf_gain")]
        public float RfGain { get; set; }

        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("device_index")]
        public int DeviceIndex { get; set; }

        [JsonProperty("centre_frequency")]
        public float CentreFrequency { get; set; }

        [JsonProperty("correction")]
        public float Correction { get; set; }
        
        [JsonProperty("channels")]
        public List<ChannelObject> Channels = new();
        

        public static RadioStoreConfig LoadRadioStoreConfig(string configPath)
        {
            RadioStoreConfig config;
            
            if (!File.Exists(configPath))
            {
                config = new RadioStoreConfig
                {
                    ConfigSavePath = configPath
                };

                config.SaveRadioStoreConfig();
            }
            
            config = JsonConvert.DeserializeObject<RadioStoreConfig>(File.ReadAllText(configPath));

            config.ConfigSavePath = configPath;

            return config;
        }

        public void SaveRadioStoreConfig()
        {
            File.WriteAllText(ConfigSavePath, JsonConvert.SerializeObject(this, Formatting.Indented));
        }
        
        public void ExportToAirbandConfigFile(string filePath)
        {
            StringBuilder configString = new();

            configString.AppendLine("devices: ({");
            configString.AppendLine($"type = \"{DeviceType}\"");
            configString.AppendLine("gain = " + RfGain);
            configString.AppendLine($"mode =  \"{Mode}\"");
            configString.AppendLine("index = " + DeviceIndex);
            configString.AppendLine("centerfreq = " + CentreFrequency);
            configString.AppendLine("correction = " + Correction);

            if (Channels.Count > 0)
            {
                configString.AppendLine("channels : (");

                foreach (ChannelObject Channel in Channels)
                {
                    configString.AppendLine("{");
                    configString.AppendLine($"freq = {Channel.Frequency}; modulation = \"{Channel.Modulation}\"; squelch_snr_threshold = {Channel.SquelchLevel}; lowpass = {Channel.LowPass}; highpass = {Channel.HighPass}");

                    if (Channel.GetOutputCount() > 0)
                    {
                        configString.AppendLine("outputs: (");

                        for (int i = 0; i < Channel.FileOutputList.Count; i++)
                        {
                            configString.Append("{" + Channel.FileOutputList[i]);

                            string end = i == Channel.FileOutputList.Count && Channel.MixerOutputList.Count == 0
                                ? "}"
                                : "},";

                            configString.AppendLine(end);
                        }

                        for (int i = 0; i < Channel.MixerOutputList.Count; i++)
                        {
                            configString.Append("{" + Channel.MixerOutputList[i]);

                            string end = i == Channel.FileOutputList.Count && Channel.MixerOutputList.Count == 0
                                ? "}"
                                : "},";

                            configString.AppendLine(end);
                        }

                        configString.AppendLine(");");
                    }

                    configString.AppendLine("}");
                }

                configString.AppendLine(");");
            }

            configString.AppendLine("} )");

            File.WriteAllText(filePath, configString.ToString());
        }
    }
}