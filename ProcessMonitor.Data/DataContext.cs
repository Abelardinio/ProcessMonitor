namespace ProcessMonitor.Data
{
    /// <summary>
    /// Class for anonymous work with data.
    /// </summary>
    public class DataContext : IDataContext
    {
        /// <summary>
        /// Data provider accessing information about push notifications subscribers.
        /// </summary>
        public ISubscribersDataProvider Subscribers { get; } = new SubscribersDataProvider();

        /// <summary>
        /// Data provider accessing information about running processes on the PC.
        /// </summary>
        public IProcessInfoDataProvider ProcessInfo { get; } = new ProcessInfoDataProvider();
    }
}
