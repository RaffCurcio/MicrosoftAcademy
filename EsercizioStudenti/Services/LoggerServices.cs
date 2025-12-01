using GestioneStudenti.Utilities;
namespace GestioneStudenti.Services
{
    public class LoggerServices
    {
        private Logger logger;

        public LoggerServices()
        {
            logger = Logger.Instance;
        }

        public void LogInfo(string message)
        {
            logger.LogInfo(message);
        }

        public void LogWarning(string message)
        {
            logger.LogWarning(message);
        }

        public void LogError(string message)
        {
            logger.LogError(message);
        }

        public IEnumerable<string> GetAllLogs()
        {
            return logger.GetLogs();
        }
    }
}