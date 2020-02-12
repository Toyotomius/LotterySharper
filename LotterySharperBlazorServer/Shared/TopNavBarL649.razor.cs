using System.Threading.Tasks;

namespace LotterySharperBlazorServer.Shared
{
    public partial class TopNavBar
    {
        protected async Task OnClick649Async()
        {
            jsonString = await lotto649Service.GetLotto649Async();
            await OnClick649.InvokeAsync(jsonString);
            cover = "cover cover-modified";
            welcome = null;
            welcome2 = null;
        }

        protected async Task OnClick649BonusAsync()
        {
            _lotteryName = "Lotto 649";
            jsonString = await lotto649Service.GetLotto649BonusAsync();
            await OnClick649Bonus.InvokeAsync(jsonString);
            await OnClickSetName.InvokeAsync(_lotteryName);
            cover = "cover cover-modified";
            welcome = null;
            welcome2 = null;
        }

        protected async Task OnClick649PairsAsync()
        {
            _lotteryName = "Lotto 649";
            jsonString = await lotto649Service.GetLotto649PairsAsync();
            await OnClick649Pairs.InvokeAsync(jsonString);
            await OnClickSetName.InvokeAsync(_lotteryName);
            cover = "cover cover-modified";
            welcome = null;
            welcome2 = null;
        }

        protected async Task OnClick649SinglesAsync()
        {
            _lotteryName = "Lotto 649";
            jsonString = await lotto649Service.GetLotto649SinglesAsync();
            await OnClick649Singles.InvokeAsync(jsonString);
            await OnClickSetName.InvokeAsync(_lotteryName);
            cover = "cover cover-modified";
            welcome = null;
            welcome2 = null;
        }

        protected async Task OnClick649TripletsAsync()
        {
            _lotteryName = "Lotto 649";
            jsonString = await lotto649Service.GetLotto649TripletsAsync();
            await OnClick649Triplets.InvokeAsync(jsonString);
            await OnClickSetName.InvokeAsync(_lotteryName);
            cover = "cover cover-modified";
            welcome = null;
            welcome2 = null;
        }
    }
}
