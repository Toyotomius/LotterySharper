using LotteryCore.GetSetObjects;
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

        public static ILottoData CreateLottoData()
        {
            return new LottoData();
        }

        public static IMakeLottoList CreateLottoList()
        {
            return new MakeLottoList();
        }

        public static INumberParsing CreateNumberParser()
        {
            return new NumberParsing();
        }

        
    }
}