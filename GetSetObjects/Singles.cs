using LotteryCore.Interfaces;

namespace LotteryCore.GetSetObjects
{
    public class Singles : ISingles
    {
        public int First { get; set; }

        public int Frequency { get; set; }
    }
}