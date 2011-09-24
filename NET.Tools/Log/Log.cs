using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using log4net.Config;
using System.Xml;
using NET.Tools.Properties;

namespace NET.Tools
{
    public static class Log
    {
        private static ILog logger;

        static Log()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(Resources.log);

                XmlConfigurator.Configure((XmlElement)doc.LastChild);

                logger = LogManager.GetLogger("Root");
                logger.Info("Initialize logging for NET.Tools!");
            }
            catch (Exception e)
            {
                Console.WriteLine("WARN: Cannot initialize Logging: " + e.Message);
            }
        }

        public static void Debug(object message)
        {
            logger.Debug(message);
        }
        public static void Debug(object message, Exception exception)
        {
            logger.Debug(message, exception);
        }
        public static void Error(object message)
        {
            logger.Error(message);
        }
        public static void Error(object message, Exception exception)
        {
            logger.Error(message, exception);
        }
        public static void Fatal(object message)
        {
            logger.Fatal(message);
        }
        public static void Fatal(object message, Exception exception)
        {
            logger.Fatal(message, exception);
        }
        public static void Info(object message)
        {
            logger.Info(message);
        }
        public static void Info(object message, Exception exception)
        {
            logger.Info(message, exception);
        }
        public static void Warn(object message)
        {
            logger.Warn(message);
        }
        public static void Warn(object message, Exception exception)
        {
            logger.Warn(message, exception);
        }
    }
}
