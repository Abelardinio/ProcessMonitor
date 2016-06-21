using System.Collections.Generic;
using ProcessMonitor.Core;

namespace ProcessMonitor.Data
{
    using System.Threading.Tasks;

    /// <summary>
    /// Data provider accessing information about push notifications subscribers.
    /// </summary>
    public class SubscribersDataProvider : ISubscribersDataProvider
    {
        /// <summary>
        /// Subscribers list.
        /// </summary>
        private static readonly IList<ISubscriber> subscribers = new List<ISubscriber>();

        /// <summary>
        /// Subscribers list.
        /// </summary>
        public IList<ISubscriber> GetList => subscribers;

        /// <summary>
        /// Adds new subscriber.
        /// </summary>
        /// <param name="subscriber">Subscriber information.</param>
        /// <returns>Async operation result.</returns>
        public Task AddAsync(ISubscriber subscriber)
        {
            return Task.Run(
                (() =>
                    {
                        lock (subscribers)
                        {
                            subscribers.Add(subscriber);
                        }
                    }));
        }
    }
}
