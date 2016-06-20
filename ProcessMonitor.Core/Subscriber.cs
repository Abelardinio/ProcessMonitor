namespace ProcessMonitor.Core
{
    /// <summary>
    /// Subscriber information.
    /// </summary>
    public class Subscriber : ISubscriber
    {
        /// <summary>
        /// Subscriber id.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Subscriber Ip.
        /// </summary>
        public long Ip { get; set; }

        /// <summary>
        /// Subscriber port.
        /// </summary>
        public int Port { get; set; }
    }
}
