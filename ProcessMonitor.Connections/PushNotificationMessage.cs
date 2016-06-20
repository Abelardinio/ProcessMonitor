namespace ProcessMonitor.Connections
{
    /// <summary>
    /// Push notification message info.
    /// </summary>
    public class PushNotificationMessage : IPushNotificationMessage
    {
        /// <summary>
        /// Notification message.
        /// </summary>
        public string Message { get; set; }
    }
}
