﻿using LotteryCore.Interfaces;

namespace LotteryCore.GetSetObjects
{
    public class LottoData : ILottoData
    {
        public string Date { get; set; }

        public int[] Numbers { get; set; }
    }
}