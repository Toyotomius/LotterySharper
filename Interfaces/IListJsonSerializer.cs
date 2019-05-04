using System.Collections.Generic;

namespace LotteryCore.Interfaces
{
    public interface IListJsonSerializer
    {
        string JSerialize<T>(List<T> lottoList);
    }
}