using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.Logging
{
    public static class Logger
    {
        private static readonly string logFilePath = "C:\\Users\\artem\\OneDrive\\Рабочий стол\\Taxi_Course_Project\\Log.txt";

        public static void Log(string message)
        {
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now}: {message}");
            }
        }
    }
}
