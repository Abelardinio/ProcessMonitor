using System.Text;
using System.Web.Script.Serialization;

namespace ProcessMonitor.Core
{
    /// <summary>
    /// Core extensions.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Serializes object to Json.
        /// </summary>
        /// <typeparam name="T">Object type.</typeparam>
        /// <param name="input">Input object.</param>
        /// <returns>Output string.</returns>
        public static string ToJson<T>(this T input)
        {
            return new JavaScriptSerializer().Serialize(input);
        }

        /// <summary>
        /// Deserializes json string into object.
        /// </summary>
        /// <typeparam name="T">Object type.</typeparam>
        /// <param name="input">Input string.</param>
        /// <returns>Retruned object.</returns>
        public static T DeserializeJson<T>(this string input)
        {
            return new JavaScriptSerializer().Deserialize<T>(input);
        }

        /// <summary>
        /// Converts byte Array to string using Utf8 Encoding.
        /// </summary>
        /// <param name="input">Input bytes.</param>
        /// <returns>Output string.</returns>
        public static string ToUtf8String(this byte[] input)
        {
            return Encoding.UTF8.GetString(input);
        }

        /// <summary>
        /// Converts Utf8 string to byte array.
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <returns>Output bytes.</returns>
        public static byte[] ToUtf8ByteArray(this string input)
        {
            return Encoding.UTF8.GetBytes(input);
        }
    }
}
