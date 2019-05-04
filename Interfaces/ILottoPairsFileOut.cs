namespace LotteryCore.Interfaces
{
    public interface ILottoPairsFileOut
    {
        void WriteFile(string lotteryName, string data);
    }
}