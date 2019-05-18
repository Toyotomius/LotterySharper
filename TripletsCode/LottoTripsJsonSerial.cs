using System.Collections.Generic;
using System.Threading.Tasks;

using LotteryCore.GetSetObjects;
using LotteryCore.Interfaces;

namespace LotteryCore.TripletsCode
{
    public class LottoTripsJsonSerial : ILottoTripsJsonSerial
    {
        private IListJsonSerializer _serializer;

        private ILottoTripsFileOut _tripsFileOut;

        public LottoTripsJsonSerial(IListJsonSerializer serializer, ILottoTripsFileOut tripsFileOut)
        {
            _serializer = serializer;
            _tripsFileOut = tripsFileOut;
        }

        public async Task TripsSerializeAsync(string lotteryName, List<Triplets> tripletList)
        {
            string tripsJson = _serializer.JSerialize(tripletList);

            await _tripsFileOut.WriteFileAsync(lotteryName, tripsJson);
        }
    }
}