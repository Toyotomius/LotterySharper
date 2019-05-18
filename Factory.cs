using LotteryCore.GetSetObjects;
using LotteryCore.Interfaces;
using LotteryCore.PairsCode;
using LotteryCore.SinglesCode;
using LotteryCore.TripletsCode;

namespace LotteryCore
{
    public static class Factory
    {
        public static IFileOut CreateFileOut()
        {
            return new FileOut();
        }

        public static IListJsonSerializer CreateJsonSerializer()
        {
            return new ListJsonSerializer();
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

        public static IFindLottoPairs CreateLottoPairs()
        {
            return new FindLottoPairs(CreatePairsJsonSerial());
        }

        public static IFindLottoSingles CreateLottoSingles()
        {
            return new LottoSingles(CreateSinglesJSonSerial());
        }

        public static IFindLottoTriplets CreateLottoTriplets()
        {
            return new FindLottoTriplets(CreateTripsJsonSerial());
        }

        public static INumberParsing CreateNumberParser()
        {
            return new NumberParsing();
        }

        public static ILottoPairsFileOut CreatePairsFileOut()
        {
            return new LottoPairsFileOut(CreateFileOut());
        }

        public static ILottoPairsJsonSerial CreatePairsJsonSerial()
        {
            return new LottoPairsJsonSerial(CreateJsonSerializer(), CreatePairsFileOut());
        }

        public static IPairs CreatePairsList()
        {
            return new Pairs();
        }

        public static ISettings CreateSettings()
        {
            return new Settings();
        }

        public static ILottoSinglesFileOut CreateSinglesFileOut()
        {
            return new LottoSinglesFileOut(CreateFileOut());
        }

        public static ILottoSinglesJsonSerial CreateSinglesJSonSerial()
        {
            return new LottoSinglesJsonSerial(CreateJsonSerializer(), CreateSinglesFileOut());
        }

        public static ISingles CreateSinglesList()
        {
            return new Singles();
        }

        public static IBeginLottoCalculations CreateStartLottoLists()
        {
            return new BeginLottoCalculations(CreateNumberParser(), CreateLottoSingles(),
                                                CreateLottoPairs(), CreateLottoTriplets());
        }

        public static ITriplets CreateTripletList()
        {
            return new Triplets();
        }

        public static ILottoTripsFileOut CreateTripsFileOut()
        {
            return new LottoTripsFileOut(CreateFileOut());
        }

        public static ILottoTripsJsonSerial CreateTripsJsonSerial()
        {
            return new LottoTripsJsonSerial(CreateJsonSerializer(), CreateTripsFileOut());
        }

        public static ISetSettings SetNewSettings()
        {
            return new SetSettings(CreateSettings(), CreateLogger());
        }
    }
}