﻿using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace KMA.C2018.MessengerService
{
    [RunInstaller(true)]
    public class ProjectInstaller : Installer
    {
        private void InitializeComponent()
        {
            _serviceProcessInstaller = new ServiceProcessInstaller();
            _serviceInstaller = new ServiceInstaller();
            _serviceProcessInstaller.Account = ServiceAccount.LocalSystem;
            _serviceProcessInstaller.Password = null;
            _serviceProcessInstaller.Username = null;
            _serviceInstaller.ServiceName = MessengerWindowsService.CurrentServiceName;
            _serviceInstaller.DisplayName = MessengerWindowsService.CurrentServiceDisplayName;
            _serviceInstaller.Description = MessengerWindowsService.CurrentServiceDescription;
            _serviceInstaller.StartType = ServiceStartMode.Automatic;
            Installers.AddRange(new Installer[]
            {
                _serviceProcessInstaller,
                _serviceInstaller
            });
        }

        public ProjectInstaller()
        {
            InitializeComponent();
        }

        private ServiceProcessInstaller _serviceProcessInstaller;
        private ServiceInstaller _serviceInstaller;
    }
}
