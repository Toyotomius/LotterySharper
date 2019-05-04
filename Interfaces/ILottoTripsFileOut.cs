namespace LotteryCore.Interfaces
{
    public interface ILottoTripsFileOut
    {
        void WriteFile(string lotteryName, string data);
    }
}