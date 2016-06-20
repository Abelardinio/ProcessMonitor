using System.Web.Http;

using ProcessMonitor.Connections;
using ProcessMonitor.Data;

namespace ProcessMonitor.WebApi
{
    /// <summary>
    /// Class of an application.
    /// </summary>
    public class WebApiApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// Application start method.
        /// </summary>
        protected void Application_Start()
        {
            var dataContext = new DataContext();

            GlobalConfiguration.Configure(WebApiConfig.Register);
            PushNotifications.Configure(dataContext, new PushNotificationConnection());
        }
    }
}
