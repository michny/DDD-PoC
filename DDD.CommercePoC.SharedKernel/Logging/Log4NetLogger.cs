using System;
using System.IO;
using System.Reflection;
using log4net;
using log4net.Core;
using ILogger = DDD.CommercePoC.SharedKernel.Interfaces.ILogger;

namespace DDD.CommercePoC.SharedKernel.Logging
{
    public class Log4NetLogger : ILogger
    {
        private static Log4NetLogger _instance;//Dictionary<Loggers, Log4NetLogger> _instances;
        private readonly ILog _log4NetAdapter;

        private Log4NetLogger()
        {
            _log4NetAdapter = LogManager.GetLogger(GetType());
        }

        /// <summary>
        /// Configures this log to be ready for use given a log4net config file. 
        /// Please note the configuration is updated automatically if the file is changed or another config-changing function is used.
        /// </summary>
        /// <param name="configFile"></param>
        public void ConfigureAndWatch(FileInfo configFile)
        {
            log4net.Config.XmlConfigurator.ConfigureAndWatch(configFile);
        }

        public static Log4NetLogger GetLogger()
        {
            return _instance ?? (_instance = new Log4NetLogger());
        }

        #region Log Methods

        private void Log(Level level, string message, Exception exception = null,
             [System.Runtime.CompilerServices.CallerMemberName] string memberName = "")
        {
            if (!_log4NetAdapter.Logger.IsEnabledFor(level)) return;

            ThreadContext.Properties["method"] = memberName;
            ThreadContext.Properties["class"] = "myclass";
            ThreadContext.Properties["user"] = "myuser";
            try
            {
                _log4NetAdapter.Logger.Log(MethodBase.GetCurrentMethod().DeclaringType, level, message, exception);
            }
            finally
            {
                ThreadContext.Properties.Clear();
            }
        }

        public void Trace(string message, Exception exception = null,
            [System.Runtime.CompilerServices.CallerMemberName] string memberName = "")
        {
            // ReSharper disable once ExplicitCallerInfoArgument
            Log(Level.Trace, message, exception, memberName);
        }

        public void Debug(string message, Exception exception = null,
            [System.Runtime.CompilerServices.CallerMemberName] string memberName = "")
        {
            // ReSharper disable once ExplicitCallerInfoArgument
            Log(Level.Debug, message, exception, memberName);
        }

        public void Info(string message, Exception exception = null,
        [System.Runtime.CompilerServices.CallerMemberName] string memberName = "")
        {
            // ReSharper disable once ExplicitCallerInfoArgument
            Log(Level.Info, message, exception, memberName);
        }

        public void Warn(string message, Exception exception = null,
        [System.Runtime.CompilerServices.CallerMemberName] string memberName = "")
        {
            // ReSharper disable once ExplicitCallerInfoArgument
            Log(Level.Warn, message, exception, memberName);
        }

        public void Error(string message, Exception exception = null,
            [System.Runtime.CompilerServices.CallerMemberName] string memberName = "")
        {
            // ReSharper disable once ExplicitCallerInfoArgument
            Log(Level.Error, message, exception, memberName);
        }

        public void Fatal(string message, Exception exception = null,
            [System.Runtime.CompilerServices.CallerMemberName] string memberName = "")
        {
            // ReSharper disable once ExplicitCallerInfoArgument
            Log(Level.Fatal, message, exception, memberName);
        }

        #endregion

        #region IsEnabled properties

        public bool IsTraceEnabled => _log4NetAdapter.Logger.IsEnabledFor(Level.Trace);
        public bool IsDebugEnabled => _log4NetAdapter.IsDebugEnabled;
        public bool IsInfoEnabled => _log4NetAdapter.IsInfoEnabled;
        public bool IsWarnEnabled => _log4NetAdapter.IsWarnEnabled;
        public bool IsErrorEnabled => _log4NetAdapter.IsErrorEnabled;
        public bool IsFatalEnabled => _log4NetAdapter.IsFatalEnabled;

        #endregion
    }
}