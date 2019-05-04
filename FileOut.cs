using System.IO;

using LotteryCore.Interfaces;

namespace LotteryCore
{
    public class FileOut : IFileOut
    {
        public void WriteFile(string lotteryName, string data)
        {
            string path = lotteryName;
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(data);
            }
        }
    }
}