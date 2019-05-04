using System.Collections.Generic;

using LotteryCore.GetSetObjects;
using LotteryCore.Interfaces;

namespace LotteryCore
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

        public void TripsSerialize(string lotteryName, List<Triplets> tripletList)
        {
            string tripsJson = _serializer.JSerialize(tripletList);

            _tripsFileOut.WriteFile(lotteryName, tripsJson);
        }
    }
}