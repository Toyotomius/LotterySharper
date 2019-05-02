using System;
using System.Collections.Generic;
using System.IO;

using LotteryCore.Interfaces;

using Newtonsoft.Json.Linq;

namespace LotteryCore
{
    public class SetSettings : ISetSettings
    {
        private List<JObject> _lotteryJObject;

        private List<string> LotteryFile { get; set; }

        private ISettings _settings;

        private ILogging _logger;

        public SetSettings(ISettings settings, ILogging logger)
        {
            _settings = settings;
            _logger = logger;
        }

        public (List<string> LotteryFile, List<JObject> LotteryJObject) ApplySettings()
        {
            JObject settingsFromFile = _settings.GetSettings();

            //TODO: Check to see if a file has been added to.Ignore it if it hasn't been.
            // TODO: Clean up logfile at various points.

            LotteryFile = new List<string>();
            _lotteryJObject = new List<JObject>();

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
                    _lotteryJObject.Add(JObject.Parse(File.ReadAllText($"{LotteryFile[i]}")));
                }
                catch (Exception) when (!File.Exists(LotteryFile[i]))
                {
                    _logger.Log($"{DateTime.Now} : " +
                                     $"File \"{LotteryFile[i]}\" Does Not Exist. Verify the folder location & is correctly named in the config.\n" +
                                     $"    * Check the config.json file for proper format.");

                    LotteryFile.Remove(LotteryFile[i]);
                }
            }

            // Reverses list to compensate for descending for loop
            _lotteryJObject.Reverse();
            return (LotteryFile, _lotteryJObject);
        }
    }
}