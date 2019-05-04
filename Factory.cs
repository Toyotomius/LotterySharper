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

        public static IListJsonSerializer CreateJsonSerializer()
        {
            return new ListJsonSerializer();
        }

        public static ILottoSingles CreateLottoSingles()
        {
            return new LottoSingles(CreateSinglesJSonSerial());
        }

        public static IFindLottoPairs CreateLottoPairs()
        {
            return new FindLottoPairs(CreatePairsJsonSerial());
        }

        public static IFindLottoTriplets CreateLottoTriplets()
        {
            return new FindLottoTriplets(CreateTripsJsonSerial());
        }

        public static ISingles CreateSinglesList()
        {
            return new Singles();
        }

        public static IPairs CreatePairsList()
        {
            return new Pairs();
        }

        public static ITriplets CreateTripletList()
        {
            return new Triplets();
        }

        public static ILottoSinglesJsonSerial CreateSinglesJSonSerial()
        {
            return new LottoSinglesJsonSerial(CreateJsonSerializer(), CreateSinglesFileOut());
        }

        public static IFileOut CreateFileOut()
        {
            return new FileOut();
        }

        public static ILottoSinglesFileOut CreateSinglesFileOut()
        {
            return new LottoSinglesFileOut(CreateFileOut());
        }

        public static ILottoPairsJsonSerial CreatePairsJsonSerial()
        {
            return new LottoPairsJsonSerial(CreateJsonSerializer(), CreatePairsFileOut());
        }

        public static ILottoPairsFileOut CreatePairsFileOut()
        {
            return new LottoPairsFileOut(CreateFileOut());
        }

        public static ILottoTripsJsonSerial CreateTripsJsonSerial()
        {
            return new LottoTripsJsonSerial(CreateJsonSerializer(), CreateTripsFileOut());
        }

        public static ILottoTripsFileOut CreateTripsFileOut()
        {
            return new LottoTripsFileOut(CreateFileOut());
        }
    }
}