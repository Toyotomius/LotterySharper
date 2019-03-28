using System.IO;
using Newtonsoft.Json.Linq;

namespace LotteryCore
{
    public class Settings
    {
        //TODO: All the things here. All of 'em.

        private JObject _settings;
        public JObject SettingsFromFile { get => _settings; }

        public void GetSettings()
        {
            _settings = JObject.Parse(File.ReadAllText("config.json"));
        }
    }
}