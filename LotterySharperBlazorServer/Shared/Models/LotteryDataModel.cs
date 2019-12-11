using System.Collections.Generic;

namespace LotterySharperBlazorServer.Shared.Models
{
    public class LotteryDataModel
    {
        public int Bonus { get; set; }
        public string Date { get; set; }
        public List<int> Numbers { get; set; }
    }
}
