using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace LotterySharperAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LottoMaxController : ControllerBase
    {
        private string LottoMaxJson = null;
        private string LottoMaxPairsJson = null;
        private string LottoMaxSinglesJson = null;
        private string LottoMaxTripletsJson = null;

        [HttpGet("Bonus")]
        public ActionResult<string> GetLottoMaxBonus()
        {
            try
            {
                using (var sr = new StreamReader("../LotterySharperConsole/Lottery Results/LottoMax/Bonus.json"))
                {
                    LottoMaxJson = sr.ReadToEnd();
                }
            }
            catch (FileNotFoundException)
            {
                return "We apologize but it seems Lotto Max bonus frequency results are missing";
            }
            return LottoMaxJson;
        }

        [HttpGet]
        public ActionResult<string> GetLottoMaxResults()
        {
            try
            {
                using (var sr = new StreamReader("../LotterySharperConsole/Data Files/LottoMax.json"))
                {
                    LottoMaxJson = sr.ReadToEnd();
                }
            }
            catch (FileNotFoundException)
            {
                return "We apologize but it seems Lotto Max's results are missing";
            }
            return LottoMaxJson;
        }

        [HttpGet("Pairs")]
        public ActionResult<string> GetMaxPairs()
        {
            try
            {
                using (var sr = new StreamReader("../LotterySharperConsole/Lottery Results/LottoMax/Pairs.json"))
                {
                    LottoMaxPairsJson = sr.ReadToEnd();
                }
            }
            catch (FileNotFoundException)
            {
                return "We apologize but it seems Lotto Max's pairs frequency results are missing";
            }

            return LottoMaxPairsJson;
        }

        [HttpGet("Singles")]
        public ActionResult<string> GetMaxSingles()
        {
            try
            {
                using (var sr = new StreamReader("../LotterySharperConsole/Lottery Results/LottoMax/Singles.json"))
                {
                    LottoMaxSinglesJson = sr.ReadToEnd();
                }
            }
            catch (FileNotFoundException)
            {
                return "We apologize but it seems Lotto Max's single frequency results are missing";
            }

            return LottoMaxSinglesJson;
        }

        [HttpGet("Triplets")]
        public ActionResult<string> GetMaxTriplets()
        {
            try
            {
                using (var sr = new StreamReader("../LotterySharperConsole/Lottery Results/LottoMax/Triplets.json"))
                {
                    LottoMaxTripletsJson = sr.ReadToEnd();
                }
            }
            catch (FileNotFoundException)
            {
                return "We apologize but it seems Lotto Max's triplets frequency results are missing";
            }

            return LottoMaxTripletsJson;
        }
    }
}
