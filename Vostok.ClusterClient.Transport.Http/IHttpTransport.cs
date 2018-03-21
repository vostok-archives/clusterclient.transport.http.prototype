using System;

namespace Vostok.Clusterclient.Transport.Http
{
    public interface IHttpTransport : ITransport
    {
        TimeSpan? ConnectionTimeout { get; set; }
    }
}