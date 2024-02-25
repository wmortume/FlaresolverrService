using System;
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;

namespace FlaresolverrService
{
    public partial class FlaresolverrService : ServiceBase
    {
        public FlaresolverrService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                //multiple commands require quotes, double & sign, cmd with /c command, /v command with quotes around env vars, then echo those env vars and surround those vars with !
                ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe", "/v /c \"set \"HOST=127.0.0.1\" && echo !HOST! && flaresolverr.exe\"") //application, command
                {
                    UseShellExecute = false,
                    WorkingDirectory = Path.Combine(Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System)), "flaresolverr")
                };
                Process process = Process.Start(processStartInfo);
                process.WaitForExit((int)TimeSpan.FromSeconds(15).TotalMilliseconds); //give cmd 15 secs to execute commands before closing it to prevent service from getting stuck on start status
            }
            catch (Exception ex)
            {
                throw new Exception("There was an issue with starting Flaresolverr", ex);
            }
        }

        protected override void OnStop()
        {
            foreach (var process in Process.GetProcessesByName("flaresolverr"))
            {
                process.Kill();
            }
        }
    }
}
