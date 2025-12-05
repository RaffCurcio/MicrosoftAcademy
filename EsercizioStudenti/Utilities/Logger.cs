using System;
using System.IO;

namespace GestioneStudenti.Utilities
{
    public sealed class Logger
    {
        private static Logger? _instance = null;
        private static readonly object _lock = new object();
        private List<string> logs = new List<string>();
        private bool isEnabled = true;

        private Logger()
        {
        }

        public static Logger Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Logger();
                    }
                    return _instance;
                }
            }
        }

        public void Log(string message)
        {
            if (!isEnabled) return;
            
            string logEntry = $"{DateTime.Now}: {message}";
            logs.Add(logEntry);
            Console.WriteLine(logEntry);

            try
            {
                File.AppendAllText("log.txt", logEntry + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to write log to file: {ex.Message}");
            }
        }
        public IEnumerable<string> GetLogs()
        {
            return logs;
        }
        public void LogInfo(string message)
        {
            Log($"INFO: {message}");
        }
        public void LogWarning(string message)
        {
            Log($"WARNING: {message}");

        }
        public void LogError(string message)
        {
            Log($"ERROR: {message}");
        }

        public void EnableLogging()
        {
            isEnabled = true;
        }

        public void DisableLogging()
        {
            isEnabled = false;
        }

        public bool IsLoggingEnabled()
        {
            return isEnabled;
        }
    }
}