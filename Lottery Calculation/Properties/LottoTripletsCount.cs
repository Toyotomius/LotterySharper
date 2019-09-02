using LotterySharper.LotteryCalculation.Interfaces;

namespace LotterySharper.LotteryCalculation.Properties
{
    public class Triplets : Pairs, ITriplets
    {
        public int Third { get; set; }
    }
}
