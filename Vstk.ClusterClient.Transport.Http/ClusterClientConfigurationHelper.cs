using System.Linq;
using System.Reflection;
using Vstk.Logging;

namespace Vstk.Clusterclient.Transport.Http
{
    public static class ClusterClientConfigurationHelper
    {
        /// <summary>
        /// Initialiazes configuration transport with a <see cref="IHttpTransport"/>.
        /// </summary>
        public static void SetupVostokHttpTransport(this IClusterClientConfiguration configuration)
        {
            configuration.Transport = CreateTransport(configuration.Log);
        }

        public static IHttpTransport CreateTransport(ILog log)
        {
            var frameworkAttribute = Assembly.GetCallingAssembly().GetCustomAttributes(typeof(System.Runtime.Versioning.TargetFrameworkAttribute), false)
                .Cast<System.Runtime.Versioning.TargetFrameworkAttribute>().FirstOrDefault();
            if (frameworkAttribute != null && frameworkAttribute.FrameworkName.StartsWith(".NETFramework"))
                return new VostokHttpTransportNetFramework(log);
            return new VostokHttpTransportNetCore(log);
        }
    }
}
