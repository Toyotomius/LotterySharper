using System.Collections.Generic;
using System.Linq;


namespace LotterySharperBlazorServer.Shared.Models
{
    public class LotteryDataModel
    {
        public int Bonus { get; set; }
        public string Date { get; set; }
        public List<int> Numbers { get; set; }
        // Crappy hack to get the blazor table to work, which can't handle lists and breaks every time I try to do this in-place.
        public string NumbersString { get
            {
                                // Tabs or spaces? Spaces in this case. Eternal debate rages on.
                return string.Join(" ", Numbers);
            } }
    }
}
