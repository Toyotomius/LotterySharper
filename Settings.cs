using System;
using System.IO;

using LotteryCore.Interfaces;

using Newtonsoft.Json.Linq;

namespace LotteryCore
{
    public class Settings : ISettings
    {
        //TODO: All the things here. All of 'em.

        private string _configContents;

        private string ConfigContents
        {
            get => this._configContents;
            set
            {
                if (new FileInfo("config.json").Length == 0)
                {
                    throw new Exception("config.json Found -- but it's empty!" +
                                        "\nFile should contain json structure & object named \"LotteryMasterFiles\"");
                }
                else if (File.ReadAllText("config.json").IndexOf("LotteryMasterFiles", StringComparison.Ordinal) == -1)
                {
                    throw new Exception(
                        "\"LotteryMasterFiles\" Not Found. Verify it's spelled correctly and is a proper json object.");
                }
                else
                {
                    this._configContents = value;
                }
            }
        }

        private JObject SettingsFromFile { get; set; }

        // Pulls settings from the config file.
        public JObject GetSettings()
        {
            ConfigContents = (File.ReadAllText("config.json"));
            SettingsFromFile = JObject.Parse(_configContents);
            return SettingsFromFile;
        }
    }
}