using LotteryCore.Interfaces;

namespace LotteryCore.GetSetObjects
{
    public class Triplets : Pairs, ITriplets
    {
        public int Third { get; set; }
    }
}