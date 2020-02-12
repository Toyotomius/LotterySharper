using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace LotterySharperAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PowerBallController : ControllerBase
    {
        private string PowerBallJson = null;
        private string PowerBallPairsJson = null;
        private string PowerBallSinglesJson = null;
        private string PowerBallTripletsJson = null;

        [HttpGet("Pairs")]
        public ActionResult<string> GetPowerBallPairs()
        {
            try
            {
                using (var sr = new StreamReader("../LotterySharperConsole/Lottery Results/USPowerBall/Pairs.json"))
                {
                    PowerBallPairsJson = sr.ReadToEnd();
                }
            }
            catch (FileNotFoundException)
            {
                return "We apologize but it seems Powerball's pairs frequency results are missing";
            }

            return PowerBallPairsJson;
        }

        [HttpGet("Singles")]
        public ActionResult<string> GetPowerBallSingles()
        {
            try
            {
                using (var sr = new StreamReader("../LotterySharperConsole/Lottery Results/USPowerBall/Singles.json"))
                {
                    PowerBallSinglesJson = sr.ReadToEnd();
                }
            }
            catch (FileNotFoundException)
            {
                return "We apologize but it seems Powerball's single frequency results are missing";
            }

            return PowerBallSinglesJson;
        }

        [HttpGet("Triplets")]
        public ActionResult<string> GetPowerBallTriplets()
        {
            try
            {
                using (var sr = new StreamReader("../LotterySharperConsole/Lottery Results/USPowerBall/Triplets.json"))
                {
                    PowerBallTripletsJson = sr.ReadToEnd();
                }
            }
            catch (FileNotFoundException)
            {
                return "We apologize but it seems Powerball's triplets frequency results are missing";
            }

            return PowerBallTripletsJson;
        }

        [HttpGet("Bonus")]
        public ActionResult<string> GetPowerBallBonus()
        {
            try
            {
                using (var sr = new StreamReader("../LotterySharperConsole/Lottery Results/USPowerBall/Bonus.json"))
                {
                    PowerBallJson = sr.ReadToEnd();
                }
            }
            catch (FileNotFoundException)
            {
                return "We apologize but it seems Powerball bonus frequency results are missing";
            }
            return PowerBallJson;
        }

        [HttpGet]
        public ActionResult<string> GetPowerBallResults()
        {
            try
            {
                using (var sr = new StreamReader("../LotterySharperConsole/Data Files/USPowerBall.json"))
                {
                    PowerBallJson = sr.ReadToEnd();
                }
            }
            catch (FileNotFoundException)
            {
                return "We apologize but it seems Powerball's results are missing";
            }
            return PowerBallJson;
        }
    }
}
