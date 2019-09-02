using LotterySharper.LotteryCalculation.Interfaces;

namespace LotterySharper.LotteryCalculation.Properties
{
    public class Pairs : Singles, IPairs
    {
        public int Second { get; set; }
    }
}
