using System;

namespace HalloSingelton
{
    internal class Logger
    {
        private static Logger _instance;
        private static object _syncLock = new object();

        public static Logger Instance
        {
            get
            {
                if (_instance == null)
                    lock (_syncLock)
                    {
                        if (_instance == null)
                            _instance = new Logger();
                    }

                return _instance;
            }
        }

        private Logger()
        {
            Info("Neuer Logger");
        }

        internal void Info(string info)
        {
            Console.WriteLine($"{DateTime.Now:g} [INFO] {info}");
        }

        internal void Error(string info)
        {
            var oldCol = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{DateTime.Now:g} [ERROR] {info}");
            Console.ForegroundColor = oldCol;
        }
    }
}
