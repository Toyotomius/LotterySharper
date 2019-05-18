using System;
using System.Threading.Tasks;

using LotteryCore.Interfaces;

namespace LotteryCore.PairsCode
{
    public class LottoPairsFileOut : ILottoPairsFileOut
    {
        private IFileOut _fileOut;

        public LottoPairsFileOut(IFileOut fileOut)
        {
            _fileOut = fileOut;
        }

        public async Task WriteFileAsync(string lotteryName, string data)
        {
            string path = $"{lotteryName}Pairs.json";
            await _fileOut.WriteFile(path, data);
            Console.WriteLine(
                $"{DateTimeOffset.Parse(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")).ToString("MM/dd/yyyy hh:mm:ss.fff tt")}" +
                $" : {lotteryName} Pairs Finished");
        }
    }
}