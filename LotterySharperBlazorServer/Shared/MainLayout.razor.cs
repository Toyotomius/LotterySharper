using LotterySharperBlazorServer.Shared.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace LotterySharperBlazorServer.Shared
{
    public partial class MainLayout
    {
        private Lotto649ResultsModel _lotto649;
        private List<LottoSinglesCount> _lottoBonus;
        private LottoMaxResultsModel _lottoMax;
        private List<LottoPairsCount> _lottoPairs;
        private List<LottoSinglesCount> _lottoSingles;
        private List<LottoTripletsCount> _lottoTriplets;
        private PowerBallResultsModel _powerBall;

        /// <summary>
        /// Click handler to convert json string to object for table.
        /// </summary>
        /// <param name="lottoJsonString">Retrieved via API call in TopNavBar OnClick methods.</param>
        public void Full649LotteryClickHandler(String lottoJsonString)
        {
            SetAllNull();
            _lotto649 = JsonConvert.DeserializeObject<Lotto649ResultsModel>(lottoJsonString);
        }

        public void FullMaxLotteryClickHandler(String lottoJsonString)
        {
            SetAllNull();
            _lottoMax = JsonConvert.DeserializeObject<LottoMaxResultsModel>(lottoJsonString);
        }
        public void FullPowerBallLotteryClickHandler(String lottoJsonString)
        {
            SetAllNull();
            _powerBall = JsonConvert.DeserializeObject<PowerBallResultsModel>(lottoJsonString);
        }

        public void LotteryBonusClickHandler(String singlesJsonString)
        {
            SetAllNull();
            _lottoBonus = JsonConvert.DeserializeObject<List<LottoSinglesCount>>(singlesJsonString);
        }

        public void LotteryPairsClickHandler(String pairsJsonString)
        {
            SetAllNull();
            _lottoPairs = JsonConvert.DeserializeObject<List<LottoPairsCount>>(pairsJsonString);
        }

        public void LotterySinglesClickHandler(String singlesJsonString)
        {
            SetAllNull();
            _lottoSingles = JsonConvert.DeserializeObject<List<LottoSinglesCount>>(singlesJsonString);
        }

        public void LotteryTripletsClickHandler(String TripletsJsonString)
        {
            SetAllNull();
            _lottoTriplets = JsonConvert.DeserializeObject<List<LottoTripletsCount>>(TripletsJsonString);
        }

        public void SetNameHandler(String lotteryName)
        {
            _lotteryName = lotteryName;
        }

        private void SetAllNull()
        {
            _powerBall = null;
            _lottoMax = null;
            _lotto649 = null;
            _lottoSingles = null;
            _lottoPairs = null;
            _lottoTriplets = null;
            _lottoBonus = null;
        }
    }
}
