using LotteryCore.Interfaces;

namespace LotteryCore
{
    public class LottoSinglesFileOut : ILottoSinglesFileOut
    {
        private IFileOut _fileOut;

        public LottoSinglesFileOut(IFileOut fileOut)
        {
            _fileOut = fileOut;
        }

        public void WriteFile(string lotteryName, string data)
        {
            string path = $"{lotteryName}Singles.json";
            _fileOut.WriteFile(path, data);
        }
    }
}