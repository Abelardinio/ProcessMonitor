using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

using ProcessMonitor.Connections;
using ProcessMonitor.Core;

namespace ProcessMonitor.Client
{
    /// <summary>
    /// Main program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point.
        /// </summary>
        public static void Main()
        {
            Task.Run(
                () =>
                {
                    RunPushNotificationAsync().Wait();
                });

            Console.ReadKey();
        }

        /// <summary>
        /// The run async.
        /// </summary>
        /// <returns>Async operation result.</returns>
        private static async Task RunPushNotificationAsync()
        {
            Console.WriteLine("Push notification initialization.");

            var ipEndPoint = new IPEndPoint(GetLocalIpAddress(), 11000);

            var subscriber = new Subscriber { Ip = ipEndPoint.Address.Address, Port = ipEndPoint.Port };

            if ((await SubscribeAsync(subscriber)).IsSuccessStatusCode)
            {
                Console.WriteLine("Successfully subscribed to push notifications.");
                await WaitForPushNotifications(ipEndPoint);
            }
        }

        /// <summary>
        /// Sends request to subscribe for push notifications.
        /// </summary>
        /// <param name="subscriber">Subscription info.</param>
        /// <returns>Response message.</returns>
        private static async Task<HttpResponseMessage> SubscribeAsync(ISubscriber subscriber)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:63088/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var content = new StringContent(subscriber.ToJson(), Encoding.UTF8, "application/json");

                return await client.PostAsync("api/processinfo/subscribe", content);
            }
        }

        /// <summary>
        /// Checks port for push notifications.
        /// </summary>
        /// <param name="ipEndPoint">IP endpoint to check.</param>
        /// <returns>Async operation result.</returns>
        private static async Task WaitForPushNotifications(IPEndPoint ipEndPoint)
        {
            while (true)
            {
                var connection = new PushNotificationConnection();

                var message = await connection.ReceiveMessageAsync(ipEndPoint);
                Console.Write("New push notification received: " + message.Message + "\n\n");
            }
        }

        /// <summary>
        /// Returns local Ip address.
        /// </summary>
        /// <returns>Local Ip adress.</returns>
        private static IPAddress GetLocalIpAddress()
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                return null;
            }

            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

            return host
                .AddressList
                .FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
        }
    }
}
