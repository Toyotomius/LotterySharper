using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotterySharperBlazorServer.Shared.Models
{
    public class LottoTripletsCount : LottoPairsCount
    {
        public int Third { get; set; }
    }
}
