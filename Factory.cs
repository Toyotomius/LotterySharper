using LotteryCore.Interfaces;

namespace LotteryCore
{
    public static class Factory
    {
        public static ISettings CreateSettings()
        {
            return new Settings();
        }

        public static ISetSettings SetNewSettings()
        {
            return new SetSettings(CreateSettings(), CreateLogger());
        }

        public static ILogging CreateLogger()
        {
            return new Logging();
        }
    }
}