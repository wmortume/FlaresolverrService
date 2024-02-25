using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace FlaresolverrService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
            serviceInstaller1.AfterInstall += ServiceInstaller_AfterInstall;
        }

        private void ServiceInstaller_AfterInstall(object sender, InstallEventArgs e) //automatically start service after installation
        {
            ServiceController serviceController = new ServiceController(serviceInstaller1.ServiceName);
            serviceController.Start();
        }
    }
}
