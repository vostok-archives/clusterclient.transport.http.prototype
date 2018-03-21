using System;
using System.Threading;
using Vstk.Clusterclient.Model;
using Vstk.Clusterclient.Transport.Http;
using Vstk.Commons.Threading;
using Vstk.Logging;
using Vstk.Logging.Logs;

namespace Vstk
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