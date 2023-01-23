using NLog;
namespace Data
{

    public class Log : ILog
    {
        private static readonly NLog.ILogger logger = LogManager.GetCurrentClassLogger();

        public Log()
        {
        }
        public void Debug(string message)
        {
            logger.Debug(message);
        }

        public void Error(string message)
        {
            logger.Error(message); ;
        }

        public void Error(Exception exp)
        {
            logger.Error(exp);
        }

        public void Info(string message)
        {
            logger.Info(message);
        }

        public void Warn(string message)
        {
            logger.Warn(message);
        }
    }
}


