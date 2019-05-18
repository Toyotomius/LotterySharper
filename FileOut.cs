using System.IO;
using System.Threading.Tasks;

using LotteryCore.Interfaces;

namespace LotteryCore
{
    public class FileOut : IFileOut
    {
        public async Task WriteFile(string lotteryName, string data)
        {
            string path = lotteryName;
            using (StreamWriter sw = new StreamWriter(path))
            {
                await sw.WriteLineAsync(data);
            }
        }
    }
}