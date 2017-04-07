using System;
using System.IO;

namespace DDD.CommercePoC.SharedKernel.Interfaces
{
    public interface ILogger
    {
        void ConfigureAndWatch(FileInfo configFile);

        void Trace(string message, Exception exception = null,
            [System.Runtime.CompilerServices.CallerMemberName] string memberName = "");
        void Debug(string message, Exception exception = null,
            [System.Runtime.CompilerServices.CallerMemberName] string memberName = "");
        void Info(string message, Exception exception = null,
            [System.Runtime.CompilerServices.CallerMemberName] string memberName = "");
        void Warn(string message, Exception exception = null,
            [System.Runtime.CompilerServices.CallerMemberName] string memberName = "");
        void Error(string message, Exception exception = null,
            [System.Runtime.CompilerServices.CallerMemberName] string memberName = "");
        void Fatal(string message, Exception exception = null,
            [System.Runtime.CompilerServices.CallerMemberName] string memberName = "");

        #region IsEnabled properties

        bool IsTraceEnabled { get; }
        bool IsDebugEnabled { get; }
        bool IsInfoEnabled { get; }
        bool IsWarnEnabled { get; }
        bool IsErrorEnabled { get; }
        bool IsFatalEnabled { get; }

        #endregion
    }
}