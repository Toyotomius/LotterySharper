﻿using LotterySharper.LotteryCalculation.Interfaces;
using System;
using System.Threading.Tasks;

namespace LotterySharper.LotteryCalculation.SinglesCode
{
    public class LottoSinglesFileOut : ILottoSinglesFileOut
    {
        private readonly IFileOut _fileOut;

        public LottoSinglesFileOut(IFileOut fileOut)
        {
            _fileOut = fileOut;
        }

        public async Task WriteFileAsync(string lotteryName, string data)
        {
            string filePath = $"./Lottery Results/{lotteryName}/Singles.json";

            await _fileOut.WriteFile(filePath, data);
            Console.WriteLine($"{DateTimeOffset.Parse(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")).ToString("MM/dd/yyyy hh:mm:ss.fff tt")}" +
                $" : {lotteryName} Singles Finished");
        }
    }
}
