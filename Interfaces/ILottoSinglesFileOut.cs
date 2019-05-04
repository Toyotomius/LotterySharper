namespace LotteryCore.Interfaces
{
    public interface ILottoSinglesFileOut
    {
        void WriteFile(string lotteryName, string data);
    }
}