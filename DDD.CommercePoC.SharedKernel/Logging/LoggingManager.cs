using System.IO;
using Castle.Windsor;
using DDD.CommercePoC.SharedKernel.Interfaces;

namespace DDD.CommercePoC.SharedKernel.Logging
{
    public static class LoggingManager
    {

        public static void Configure(FileInfo configFileInfo)
        {
            GetLogger().ConfigureAndWatch(configFileInfo);
        }

        public static ILogger GetLogger()
        {
            return Log4NetLogger.GetLogger();
        }
    }
}