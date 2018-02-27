using System;

namespace Vstk.Clusterclient.Transport.Http
{
    public interface IHttpTransport : ITransport
    {
        TimeSpan? ConnectionTimeout { get; set; }
    }
}