using ProcessMonitor.Core;

namespace ProcessMonitor.Connections
{
    /// <summary>
    /// Extensions class.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Serializes push notification message into byte array.
        /// </summary>
        /// <param name="message">Push notification message.</param>
        /// <returns>Byte array.</returns>
        public static byte[] Serialize(this IPushNotificationMessage message)
        {
            return message.ToJson().ToUtf8ByteArray();
        }

        /// <summary>
        /// Deseerializes byte array message into push notification.
        /// </summary>
        /// <param name="message">Byte array.</param>
        /// <returns>Push notification message.</returns>
        public static IPushNotificationMessage Deserialize(this byte[] message)
        {
            return message.ToUtf8String().DeserializeJson<PushNotificationMessage>();
        }
    }
}
