using System.Web;

namespace DDD.CommercePoC.Web
{
    public static class LoggingConfig
    {
        public static void Configure(HttpServerUtility server)
        {
            //LoggingManager.Configure(new FileInfo(server.MapPath("~\bin\\Configs\\log4net.config")));
        }
    }
}