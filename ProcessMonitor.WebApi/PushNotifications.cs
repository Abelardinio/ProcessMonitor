using ProcessMonitor.Connections;
using ProcessMonitor.Data;
using ProcessMonitor.Recorder;

namespace ProcessMonitor.WebApi
{
    /// <summary>
    /// Push notifications configure class.
    /// </summary>
    public static class PushNotifications
    {
        /// <summary>
        /// Data provider accessing information about running processes on the PC.
        /// </summary>
        private static IProcessInfoDataProvider processInfo;

        /// <summary>
        /// Data provider accessing information about push notifications subscribers.
        /// </summary>
        private static ISubscribersDataProvider subscribers;

        /// <summary>
        /// Push notification connection instance.
        /// </summary>
        private static IPushNotificationConnection pushNotificationConnection;

        /// <summary>
        /// Configures push notifications.
        /// </summary>
        /// <param name="dataContext">Class for anonymous work with data.</param>
        /// <param name="connection">Push notification connection instance.</param>
        public static void Configure(IDataContext dataContext, IPushNotificationConnection connection)
        {
            processInfo = dataContext.ProcessInfo;
            subscribers = dataContext.Subscribers;
            pushNotificationConnection = connection;

            processInfo.AddHighloadEventHandler(NotifyHighLoad);
        }

        /// <summary>
        /// Notifies subscribers about High Load.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="highLoadEventArgs">Object with information about high load.</param>
        private static async void NotifyHighLoad(object sender, HighLoadEventArgs highLoadEventArgs)
        {
            await
                pushNotificationConnection.NotifyAsync(
                    subscribers.GetList,
                    new PushNotificationMessage { Message = highLoadEventArgs.GetMessage() });
        }
    }
}