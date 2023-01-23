namespace Data
{
    public interface ILog
    {

        void Info(string message);
        void Warn(string message);
        void Debug(string message);
        void Error(string message);
        void Error(Exception exp);

    }
}


