using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using ProcessMonitor.Core;

namespace ProcessMonitor.Connections
{
    /// <summary>
    /// Interface of Push notification connection class.
    /// </summary>
    public interface IPushNotificationConnection
    {
        /// <summary>
        /// Notifies subscribed devices.
        /// </summary>
        /// <param name="subscribers">Subscriber list.</param>
        /// <param name="message">Push notification message.</param>
        /// <returns>Async operation result.</returns>
        Task NotifyAsync(IList<ISubscriber> subscribers, IPushNotificationMessage message);

        /// <summary>
        /// Receives push notification message.
        /// </summary>
        /// <param name="locaEndPoint">Local endpoint.</param>
        /// <returns>Push notification message.</returns>
        Task<IPushNotificationMessage> ReceiveMessageAsync(IPEndPoint locaEndPoint);
    }
}
