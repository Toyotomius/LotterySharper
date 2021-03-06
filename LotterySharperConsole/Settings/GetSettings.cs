﻿using LotterySharper.LotteryCalculation.Interfaces;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LotterySharper.Settings
{
    public class GetSettings : IGetSettings
    {
        private readonly ISetSettings _settings;

        internal GetSettings(ISetSettings settings)
        {
            _settings = settings;
        }

        public async Task<(List<string> lotteryFile, List<JObject> lotteryJObject, bool scrapeWebsites)> RetrieveSettings()
        {
            // Retrieves filename, data and scrape settings. Removes the boolean to return to calling method and passes
            // new tuple on.
            (List<string> lotteryFile, List<JObject> lotteryJObject, bool scrapeWebsites) configInfo = await _settings.ApplySettingsAsync();

            return configInfo;
        }
    }
}
