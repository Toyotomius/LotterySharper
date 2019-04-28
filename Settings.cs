using System;
using System.Collections.Generic;
using System.IO;

using Newtonsoft.Json.Linq;

namespace LotteryCore
{
    public class Settings
    {
        //TODO: All the things here. All of 'em.

        private string _configContents;

        public string ConfigContents
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

        private List<JObject> LotteryJObject;

        private List<string> LotteryFile { get; set; }

        public const string LogFile = "logfile.txt";

        // Pulls settings from the config file.
        public JObject GetSettings()
        {
            ConfigContents = (File.ReadAllText("config.json"));
            SettingsFromFile = JObject.Parse(_configContents);
            return SettingsFromFile;
        }

        public (List<string> LotteryFile, List<JObject> LotteryJObject) ApplySettings()
        {
            JObject settingsFromFile = GetSettings();

            //TODO: Check to see if a file has been added to.Ignore it if it hasn't been.
            // TODO: Clean up logfile at various points.

            LotteryFile = new List<string>();
            LotteryJObject = new List<JObject>();

            // Takes each item from the array of json lottery files and adds it to a list
            foreach (JToken itm in settingsFromFile["LotteryMasterFiles"])
            {
                LotteryFile.Add(itm.ToString());
            }

            // Descending for loop to allow for removing any files that are not present while logging such.
            for (var i = LotteryFile.Count - 1; i >= 0; i--)
            {
                try
                {
                    // tries to create list of json objects from the contents of the file from config
                    LotteryJObject.Add(JObject.Parse(File.ReadAllText($"{LotteryFile[i]}")));
                }
                catch (Exception) when (!File.Exists(LotteryFile[i]))
                {
                    using (StreamWriter sw = new StreamWriter(LogFile, append: true))
                    {
                        sw.WriteLine($"{DateTime.Now} : " +
                                     $"File \"{LotteryFile[i]}\" Does Not Exist. Verify the folder location & is correctly named in the config.\n" +
                                     $"    * Check the config.json file for proper format.");
                    }
                    LotteryFile.Remove(LotteryFile[i]);
                    continue;
                }
            }

            // Reverses list to compensate for descending for loop
            LotteryJObject.Reverse();
            return (LotteryFile, LotteryJObject);
        }
    }
}