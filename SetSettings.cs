﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using LotteryCore.Interfaces;

using Newtonsoft.Json.Linq;

namespace LotteryCore
{
    public class SetSettings : ISetSettings
    {
        private ILogging _logger;
        private List<JObject> _lotteryJObject;

        private ISettings _settings;

        public SetSettings(ISettings settings, ILogging logger)
        {
            _settings = settings;
            _logger = logger;
        }

        private List<string> LotteryFile { get; set; }

        public async Task<(List<string> LotteryFile, List<JObject> LotteryJObject)> ApplySettingsAsync()
        {
            Task<JObject> settingsFromFileTask = _settings.GetSettings();
            JObject settingsFromFile = await settingsFromFileTask;

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