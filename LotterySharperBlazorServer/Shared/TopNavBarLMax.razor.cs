using System.Threading.Tasks;

namespace LotterySharperBlazorServer.Shared
{
    public partial class TopNavBar
    {
        protected async Task OnClickMaxAsync()
        {
            jsonString = await lottoMaxService.GetLottoMaxAsync();
            await OnClickMax.InvokeAsync(jsonString);
            cover = "cover cover-modified";
            welcome = null;
            welcome2 = null;
        }

        protected async Task OnClickMaxBonusAsync()
        {
            _lotteryName = "Lotto Max";
            jsonString = await lottoMaxService.GetLottoMaxBonusAsync();
            await OnClickMaxBonus.InvokeAsync(jsonString);
            await OnClickSetName.InvokeAsync(_lotteryName);
            cover = "cover cover-modified";
            welcome = null;
            welcome2 = null;
        }

        protected async Task OnClickMaxPairsAsync()
        {
            _lotteryName = "Lotto Max";
            jsonString = await lottoMaxService.GetLottoMaxPairsAsync();
            await OnClickMaxPairs.InvokeAsync(jsonString);
            await OnClickSetName.InvokeAsync(_lotteryName);
            cover = "cover cover-modified";
            welcome = null;
            welcome2 = null;
        }

        protected async Task OnClickMaxSinglesAsync()
        {
            _lotteryName = "Lotto Max";
            jsonString = await lottoMaxService.GetLottoMaxSinglesAsync();
            await OnClickMaxSingles.InvokeAsync(jsonString);
            await OnClickSetName.InvokeAsync(_lotteryName);
            cover = "cover cover-modified";
            welcome = null;
            welcome2 = null;
        }

        protected async Task OnClickMaxTripletsAsync()
        {
            _lotteryName = "Lotto Max";
            jsonString = await lottoMaxService.GetLottoMaxTripletsAsync();
            await OnClickMaxTriplets.InvokeAsync(jsonString);
            await OnClickSetName.InvokeAsync(_lotteryName);
            cover = "cover cover-modified";
            welcome = null;
            welcome2 = null;
        }
    }
}
