namespace ProcessMonitor.Core
{
    /// <summary>
    /// Subscriber information.
    /// </summary>
    public interface ISubscriber
    {
        /// <summary>
        /// Subscriber id.
        /// </summary>
        long Id { get; }
        
        /// <summary>
        /// Subscriber Ip.
        /// </summary>
        long Ip { get; }

        /// <summary>
        /// Subscriber port.
        /// </summary>
        int Port { get; }
    }
}
