using LotteryCore.Interfaces;

namespace LotteryCore
{
    public class LottoTripsFileOut : ILottoTripsFileOut
    {
        private IFileOut _fileOut;

        public LottoTripsFileOut(IFileOut fileOut)
        {
            _fileOut = fileOut;
        }

        public void WriteFile(string lotteryName, string data)
        {
            string path = $"{lotteryName}Triplets.json";
            _fileOut.WriteFile(path, data);
        }
    }
}