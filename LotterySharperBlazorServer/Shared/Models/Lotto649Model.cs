using System.Collections.Generic;

namespace LotterySharperBlazorServer.Shared.Models
{
    public class Lotto
    {
        public List<LottoData> Lotto649 { get; set; }
    }

    public class LottoData
    {
        public int Bonus { get; set; }
        public string Date { get; set; }
        public List<int> Numbers { get; set; }
    }
}
