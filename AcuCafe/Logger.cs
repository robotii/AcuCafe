using AcuCafe.interfaces;

namespace AcuCafe
{
    public class Logger : ILogger
    {
        private readonly string _fileName;

        public Logger(string fileName)
        {
            _fileName = fileName;
        }
        public void Log(string message)
        {
            System.IO.File.WriteAllText(_fileName, message);
        }
    }
}