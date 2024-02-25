using System.ServiceProcess;

namespace FlaresolverrService
{
    internal static class Program
    {
        /// <summary>
        /// Flaresolverr Service
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new FlaresolverrService()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
