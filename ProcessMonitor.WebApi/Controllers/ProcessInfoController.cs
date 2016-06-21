using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

using ProcessMonitor.Core;
using ProcessMonitor.Data;

namespace ProcessMonitor.WebApi.Controllers
{
    using System.Linq;

    /// <summary>
    /// Controller with Process info methods. 
    /// </summary>
    public class ProcessInfoController : ApiController
    {
        /// <summary>
        /// Data provider accessing information about push notifications subscribers.
        /// </summary>
        private readonly ISubscribersDataProvider subscribers;

        /// <summary>
        /// Data provider accessing information about running processes on the PC.
        /// </summary>
        private readonly IProcessInfoDataProvider processInfo;

        /// <summary>
        /// Public constractor.
        /// </summary>
        public ProcessInfoController()
        {
            var dataContext = new DataContext();

            subscribers = dataContext.Subscribers;
            processInfo = dataContext.ProcessInfo;
        }

        /// <summary>
        /// Adds new subscriber to highload push notifications.
        /// </summary>
        /// <param name="subscriber">Subscriber information.</param>
        /// <returns>Response message.</returns>
        [HttpPost]
        public async Task<HttpResponseMessage> Subscribe([FromBody] Subscriber subscriber)
        {
            await subscribers.AddAsync(subscriber);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        /// <summary>
        /// Return Process Info list.
        /// </summary>
        /// <returns>Process info list.</returns>
        public async Task<IEnumerable<IProcessInfo>> Get()
        {
            return await processInfo.GetProcessesAsync();
        }

        /// <summary>
        /// Returns Process by its id.
        /// </summary>
        /// <param name="id">Process id.</param>
        /// <returns>Process info.</returns>
        public async Task<IProcessInfo> Get(int id)
        {
            return (await processInfo.GetProcessesAsync()).First(process => process.Id == id);
        }
    }
}