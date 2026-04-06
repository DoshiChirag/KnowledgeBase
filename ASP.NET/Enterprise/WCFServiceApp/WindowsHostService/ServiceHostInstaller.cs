using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;

namespace WindowsHostService
{
    [RunInstaller(true)]
    public partial class ServiceHostInstaller : System.Configuration.Install.Installer
    {
        public ServiceHostInstaller()
        {
            InitializeComponent();

            Installers.Add(serviceProcessInstaller1);
        }

        private void serviceInstaller1_AfterInstall(object sender, InstallEventArgs e)
        {

        }
    }
}
