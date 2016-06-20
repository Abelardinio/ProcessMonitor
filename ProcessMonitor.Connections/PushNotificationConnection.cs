using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using ProcessMonitor.Core;

namespace ProcessMonitor.Connections
{
    /// <summary>
    /// Push notification connection class.
    /// </summary>
    public class PushNotificationConnection : ConnectionBase, IPushNotificationConnection
    {
        /// <summary>
        /// Notifies subscribed devices.
        /// </summary>
        /// <param name="subscribers">Subscriber list.</param>
        /// <param name="message">Push notification message.</param>
        /// <returns>Async operation result.</returns>
        public async Task NotifyAsync(IList<ISubscriber> subscribers, IPushNotificationMessage message)
        {
            foreach (var subscriber in subscribers)
            {
                await TcpSendAsync(new IPEndPoint(subscriber.Ip, subscriber.Port), message.Serialize());
            }
        }

        /// <summary>
        /// Receives push notification message.
        /// </summary>
        /// <param name="locaEndPoint">Local endpoint.</param>
        /// <returns>Push notification message.</returns>
        public async Task<IPushNotificationMessage> ReceiveMessageAsync(IPEndPoint locaEndPoint)
        {
            return (await TcpReceiveAsync(locaEndPoint)).Deserialize();
        }
    }
}
