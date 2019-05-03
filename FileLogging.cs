using System.IO;

using LotteryCore.Interfaces;

namespace LotteryCore
{
    public class FileLogging : IFileLogging
    {
        private string logFile = "Logfile.txt";

        public void Log(string message)
        {
            using (StreamWriter sw = new StreamWriter(logFile, append: true))
            {
                sw.WriteLine(message);
            }
        }
    }
}