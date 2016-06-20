namespace ProcessMonitor.Data
{
    /// <summary>
    /// Interface for anonymous work with data.
    /// </summary>
    public interface IDataContext
    {
        /// <summary>
        /// Data provider accessing information about push notifications subscribers.
        /// </summary>
        ISubscribersDataProvider Subscribers { get; }

        /// <summary>
        /// Data provider accessing information about running processes on the PC.
        /// </summary>
        IProcessInfoDataProvider ProcessInfo { get; }
    }
}
