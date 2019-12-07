using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace LotterySharperAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Lotto649Controller : ControllerBase
    {
        private string Lotto649Json = null;
        private string Lotto649PairsJson = null;
        private string Lotto649SinglesJson = null;
        private string Lotto649TripletsJson = null;

        [HttpGet("Singles")]
        public ActionResult<string> Get649Singles()
        {
            try
            {
                using (var sr = new StreamReader("../LotterySharperConsole/Lottery Results/Lotto649/Singles.json"))
                {
                    Lotto649SinglesJson = sr.ReadToEnd();
                }
            }
            catch (FileNotFoundException)
            {
                return "We apologize but it seems Lotto 649's single frequency results are missing";
            }

            return Lotto649SinglesJson;
        }

        [HttpGet("Pairs")]
        public ActionResult<string> Get649SPairs()
        {
            try
            {
                using (var sr = new StreamReader("../LotterySharperConsole/Lottery Results/Lotto649/Pairs.json"))
                {
                    Lotto649PairsJson = sr.ReadToEnd();
                }
            }
            catch (FileNotFoundException)
            {
                return "We apologize but it seems Lotto 649's pairs frequency results are missing";
            }

            return Lotto649PairsJson;
        }

        [HttpGet("Triplets")]
        public ActionResult<string> Get649Triplets()
        {
            try
            {
                using (var sr = new StreamReader("../LotterySharperConsole/Lottery Results/Lotto649/Triplets.json"))
                {
                    Lotto649TripletsJson = sr.ReadToEnd();
                }
            }
            catch (FileNotFoundException)
            {
                return "We apologize but it seems Lotto 649's triplets frequency results are missing";
            }

            return Lotto649TripletsJson;
        }

        [HttpGet("Bonus")]
        public ActionResult<string> GetLotto649Bonus()
        {
            try
            {
                using (var sr = new StreamReader("../LotterySharperConsole/Lottery Results/Lotto649/Bonus.json"))
                {
                    Lotto649Json = sr.ReadToEnd();
                }
            }
            catch (FileNotFoundException)
            {
                return "We apologize but it seems Lotto 649 bonus frequency results are missing";
            }
            return Lotto649Json;
        }

        [HttpGet]
        public ActionResult<string> GetLotto649Results()
        {
            try
            {
                using (var sr = new StreamReader("../LotterySharperConsole/Data Files/Lotto649.json"))
                {
                    Lotto649Json = sr.ReadToEnd();
                }
            }
            catch (FileNotFoundException)
            {
                return "We apologize but it seems Lotto 649's results are missing";
            }
            return Lotto649Json;
        }
    }
}
