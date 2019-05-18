﻿using System.Collections.Generic;
using System.Threading.Tasks;

using Newtonsoft.Json.Linq;

namespace LotteryCore.Interfaces
{
    public interface ISetSettings
    {
        Task<(List<string> LotteryFile, List<JObject> LotteryJObject)> ApplySettingsAsync();
    }
}