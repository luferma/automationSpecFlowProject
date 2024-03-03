using log4net;
using log4net.Config;
using System.IO;
using System.Reflection;

namespace taxchat
{
    class Logger
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void logDebug(string message){
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
            var logger = LogManager.GetLogger(typeof(Logger));
            logger.Debug(message);
        }

        public void logInfo(string message){
            log.Info(message);
        }

        public void logWarn(string message){
            log.Warn(message);
        }

        public void logError(string message){
            log.Error(message);
        }

        public void logFatal(string message){
            log.Fatal(message);
        }
    }
}