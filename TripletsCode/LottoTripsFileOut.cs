﻿using System;
using System.Threading.Tasks;

using LotteryCore.Interfaces;

namespace LotteryCore.TripletsCode
{
    public class LottoTripsFileOut : ILottoTripsFileOut
    {
        private IFileOut _fileOut;

        public LottoTripsFileOut(IFileOut fileOut)
        {
            _fileOut = fileOut;
        }

        public async Task WriteFileAsync(string lotteryName, string data)
        {
            string path = $"{lotteryName}Triplets.json";
            await _fileOut.WriteFile(path, data);
            Console.WriteLine(
                $"{DateTimeOffset.Parse(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")).ToString("MM/dd/yyyy hh:mm:ss.fff tt")}" +
                $" : {lotteryName} Triplets Finished");
        }
    }
}