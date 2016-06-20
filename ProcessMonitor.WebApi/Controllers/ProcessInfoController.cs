using System.Web.Http;
using ProcessMonitor.Core;
using ProcessMonitor.Data;

namespace ProcessMonitor.WebApi.Controllers
{
    /// <summary>
    /// Controller with Process info methods. 
    /// </summary>
    public class ProcessInfoController : ApiController
    {
        /// <summary>
        /// Data provider accessing information about push notifications subscribers.
        /// </summary>
        private readonly ISubscribersDataProvider subscribers = new SubscribersDataProvider();

        /// <summary>
        /// Adds new subscriber to highload push notifications.
        /// </summary>
        /// <param name="subscriber">Subscriber information.</param>
        [HttpPost]
        public bool Subscribe([FromBody] Subscriber subscriber)
        {
            subscribers.Add(subscriber);

            return true;
        }
    }
}