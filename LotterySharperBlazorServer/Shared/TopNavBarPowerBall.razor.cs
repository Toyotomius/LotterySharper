using System.Threading.Tasks;

namespace LotterySharperBlazorServer.Shared
{
    public partial class TopNavBar
    {
        protected async Task OnClickPowerBallAsync()
        {
            jsonString = await powerBallService.GetPowerBallAsync();
            await OnClickPowerBall.InvokeAsync(jsonString);
            cover = "cover cover-modified";
            welcome = null;
            welcome2 = null;
        }

        protected async Task OnClickPowerBallBonusAsync()
        {
            _lotteryName = "PowerBall";
            jsonString = await powerBallService.GetPowerBallBonusAsync();
            await OnClickPowerBallBonus.InvokeAsync(jsonString);
            await OnClickSetName.InvokeAsync(_lotteryName);
            cover = "cover cover-modified";
            welcome = null;
            welcome2 = null;
        }

        protected async Task OnClickPowerBallPairsAsync()
        {
            _lotteryName = "PowerBall";
            jsonString = await powerBallService.GetPowerBallPairsAsync();
            await OnClickPowerBallPairs.InvokeAsync(jsonString);
            await OnClickSetName.InvokeAsync(_lotteryName);
            cover = "cover cover-modified";
            welcome = null;
            welcome2 = null;
        }

        protected async Task OnClickPowerBallSinglesAsync()
        {
            _lotteryName = "PowerBall";
            jsonString = await powerBallService.GetPowerBallSinglesAsync();
            await OnClickPowerBallSingles.InvokeAsync(jsonString);
            await OnClickSetName.InvokeAsync(_lotteryName);
            cover = "cover cover-modified";
            welcome = null;
            welcome2 = null;
        }

        protected async Task OnClickPowerBallTripletsAsync()
        {
            _lotteryName = "PowerBall";
            jsonString = await powerBallService.GetPowerBallTripletsAsync();
            await OnClickPowerBallTriplets.InvokeAsync(jsonString);
            await OnClickSetName.InvokeAsync(_lotteryName);
            cover = "cover cover-modified";
            welcome = null;
            welcome2 = null;
        }
    }
}
