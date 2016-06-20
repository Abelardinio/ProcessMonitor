using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace ProcessMonitor.Connections
{
    /// <summary>
    /// Base connection class providing nethods for Net data exchange.
    /// </summary>
    public abstract class ConnectionBase 
    {
        /// <summary>
        /// Sends data to remote IP endpoint by tcp.
        /// </summary>
        /// <param name="endPoint">Remote IP endpoint.</param>
        /// <param name="data">Send data.</param>
        /// <returns>Async operation result.</returns>
        protected Task TcpSendAsync(IPEndPoint endPoint, byte[] data)
        {
            return SendAsync(endPoint, data, new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp));
        }

        /// <summary>
        /// Sends data to remote IP endpoint.
        /// </summary>
        /// <param name="endPoint">Remote network endpoint.</param>
        /// <param name="data">Send data.</param>
        /// <param name="socket">Socket interface.</param>
        /// <returns>Async operation result.</returns>
        protected Task SendAsync(IPEndPoint endPoint, byte[] data, Socket socket)
        {
            return Task.Run(
                () =>
                    {
                        using (socket)
                        {
                            socket.Connect(endPoint);
                            socket.Send(data);
                        }
                    });
        }

        /// <summary>
        /// Returns task awaiting for data receiving by tcp.
        /// </summary>
        /// <param name="endPoint">Current application endpoint.</param>
        /// <returns>Received bytes.</returns>
        protected Task<byte[]> TcpReceiveAsync(IPEndPoint endPoint)
        {
            return ReceiveAsync(endPoint, new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp));
        }

        /// <summary>
        /// Returns task awaiting for data receiving.
        /// </summary>
        /// <param name="endPoint">Current application endpoint.</param>
        /// <param name="socket">Socket interface.</param>
        /// <returns>Received bytes.</returns>
        protected Task<byte[]> ReceiveAsync(IPEndPoint endPoint, Socket socket)
        {
            return Task.Run(
                () =>
                    {
                        using (socket)
                        {
                            socket.Bind(endPoint);
                            socket.Listen(10);

                            var bytes = new byte[1024];
                            var connectedSocket = socket.Accept();
                            var bytesReceived = connectedSocket.Receive(bytes);

                            return bytes.Take(bytesReceived).ToArray();
                        }
                    });
        }
    }
}
