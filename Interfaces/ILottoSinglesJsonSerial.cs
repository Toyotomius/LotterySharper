using System.Collections.Generic;
using System.Threading.Tasks;

using LotteryCore.GetSetObjects;

namespace LotteryCore.Interfaces
{
    public interface ILottoSinglesJsonSerial
    {
        Task SinglesSerializeAsync(string lotteryName, List<Singles> singlesList);
    }
}