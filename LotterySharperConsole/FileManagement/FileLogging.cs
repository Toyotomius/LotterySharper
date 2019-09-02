﻿using LotterySharper.LotteryCalculation.Interfaces;
using System.IO;

namespace LotterySharper.FileManagement
{
    public class FileLogging : IFileLogging
    {
        private readonly string _logFile = "Logfile.txt";

        public void Log(string message)
        {
            using (var sw = new StreamWriter(_logFile, true))
            {
                sw.WriteLine(message);
            }
        }
    }
}
