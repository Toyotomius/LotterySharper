using LotterySharper.LotteryCalculation.Interfaces;
using System;
using System.Threading.Tasks;

namespace LotterySharper.LotteryCalculation.BonusCode
{
    public class LottoBonusFileOut : ILottoBonusFileOut
    {
        private readonly IFileOut _fileOut;

        public LottoBonusFileOut(IFileOut fileOut)
        {
            _fileOut = fileOut;
        }

        public async Task WriteFileAsync(string lotteryName, string data)
        {
            string filePath = $"./Lottery Results/{lotteryName}/Bonus.json";

            await _fileOut.WriteFile(filePath, data);
            Console.WriteLine($"{DateTimeOffset.Parse(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")).ToString("MM/dd/yyyy hh:mm:ss.fff tt")}" +
                $" : {lotteryName} Bonus Finished");
        }
    }
}
