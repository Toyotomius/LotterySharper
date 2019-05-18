using LotteryCore.Interfaces;

namespace LotteryCore.GetSetObjects
{
    public class Pairs : Singles, IPairs
    {
        public int Second { get; set; }
    }
}