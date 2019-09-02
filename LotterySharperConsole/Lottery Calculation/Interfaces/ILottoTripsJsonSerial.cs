using System.Collections.Generic;
using System.Threading.Tasks;

namespace LotterySharper.LotteryCalculation.Interfaces
{
    public interface ILottoTripsJsonSerial
    {
        Task TripsSerializeAsync(string lotteryName, IList<ITriplets> tripletList);
    }
}
