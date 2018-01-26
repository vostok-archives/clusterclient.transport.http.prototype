using System;
using System.Threading;
using Vostok.Clusterclient.Model;
using Vostok.Clusterclient.Transport.Http;
using Vostok.Commons.Threading;
using Vostok.Logging;
using Vostok.Logging.Logs;

namespace Vostok
{
    public abstract class TransportTestsBase
    {
        protected readonly IHttpTransport Transport;

        protected TransportTestsBase()
        {
            ILog log = new ConsoleLog();
            Transport = ClusterClientConfigurationHelper.CreateTransport(log);

            ThreadPoolUtility.Setup(log);
        }

        protected Response Send(Request request, TimeSpan? timeout = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Transport.SendAsync(request, timeout ?? TimeSpan.FromMinutes(1), cancellationToken).GetAwaiter().GetResult();
        }
    }
}