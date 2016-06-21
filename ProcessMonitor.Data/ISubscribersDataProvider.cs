using System.Collections.Generic;
using ProcessMonitor.Core;

namespace ProcessMonitor.Data
{
    using System.Threading.Tasks;

    /// <summary>
    /// Data provider accessing information about push notifications subscribers.
    /// </summary>
    public interface ISubscribersDataProvider
    {
        /// <summary>
        /// Subscribers list.
        /// </summary>
        IList<ISubscriber> GetList { get; }

        /// <summary>
        /// Adds new subscriber.
        /// </summary>
        /// <param name="subscriber">Subscriber information.</param>
        Task AddAsync(ISubscriber subscriber);
    }
}