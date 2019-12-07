using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace LotterySharperAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class USPowerballController : ControllerBase
    {
        private string USPowerballJson = null;
        private string USPowerballPairsJson = null;
        private string USPowerballSinglesJson = null;
        private string USPowerballTripletsJson = null;

        [HttpGet("Pairs")]
        public ActionResult<string> GetMaxPairs()
        {
            try
            {
                using (var sr = new StreamReader("../LotterySharperConsole/Lottery Results/USPowerball/Pairs.json"))
                {
                    USPowerballPairsJson = sr.ReadToEnd();
                }
            }
            catch (FileNotFoundException)
            {
                return "We apologize but it seems US Powerball's pairs frequency results are missing";
            }

            return USPowerballPairsJson;
        }

        [HttpGet("Singles")]
        public ActionResult<string> GetMaxSingles()
        {
            try
            {
                using (var sr = new StreamReader("../LotterySharperConsole/Lottery Results/USPowerball/Singles.json"))
                {
                    USPowerballSinglesJson = sr.ReadToEnd();
                }
            }
            catch (FileNotFoundException)
            {
                return "We apologize but it seems US Powerball's single frequency results are missing";
            }

            return USPowerballSinglesJson;
        }

        [HttpGet("Triplets")]
        public ActionResult<string> GetMaxTriplets()
        {
            try
            {
                using (var sr = new StreamReader("../LotterySharperConsole/Lottery Results/USPowerball/Triplets.json"))
                {
                    USPowerballTripletsJson = sr.ReadToEnd();
                }
            }
            catch (FileNotFoundException)
            {
                return "We apologize but it seems US Powerball's triplets frequency results are missing";
            }

            return USPowerballTripletsJson;
        }

        [HttpGet("Bonus")]
        public ActionResult<string> GetUSPowerballBonus()
        {
            try
            {
                using (var sr = new StreamReader("../LotterySharperConsole/Lottery Results/USPowerball/Bonus.json"))
                {
                    USPowerballJson = sr.ReadToEnd();
                }
            }
            catch (FileNotFoundException)
            {
                return "We apologize but it seems US Powerball bonus frequency results are missing";
            }
            return USPowerballJson;
        }

        [HttpGet]
        public ActionResult<string> GetUSPowerballResults()
        {
            try
            {
                using (var sr = new StreamReader("../LotterySharperConsole/Data Files/USPowerball.json"))
                {
                    USPowerballJson = sr.ReadToEnd();
                }
            }
            catch (FileNotFoundException)
            {
                return "We apologize but it seems US Powerball's results are missing";
            }
            return USPowerballJson;
        }
    }
}
