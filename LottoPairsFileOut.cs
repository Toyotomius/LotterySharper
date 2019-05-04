using LotteryCore.Interfaces;

namespace LotteryCore
{
    public class LottoPairsFileOut : ILottoPairsFileOut
    {
        private IFileOut _fileOut;

        public LottoPairsFileOut(IFileOut fileOut)
        {
            _fileOut = fileOut;
        }

        public void WriteFile(string lotteryName, string data)
        {
            string path = $"{lotteryName}Pairs.json";
            _fileOut.WriteFile(path, data);
        }
    }
}