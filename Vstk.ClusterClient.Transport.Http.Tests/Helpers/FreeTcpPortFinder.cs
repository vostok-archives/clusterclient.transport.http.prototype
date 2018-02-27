using System.Net;
using System.Net.Sockets;

namespace Vstk.Helpers
{
    internal static class FreeTcpPortFinder
    {
        public static int GetFreePort()
        {
            var listener = new TcpListener(IPAddress.Loopback, 0);
            try
            {
                listener.Start();
                return ((IPEndPoint)listener.LocalEndpoint).Port;
            }
            finally
            {
                listener.Stop();
            }
        }
    }
}