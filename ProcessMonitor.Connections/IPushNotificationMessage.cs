namespace ProcessMonitor.Connections
{
    /// <summary>
    /// Interface of Push notification message class.
    /// </summary>
    public interface IPushNotificationMessage
    {
        /// <summary>
        /// Notification message.
        /// </summary>
        string Message { get; }
    }
}
