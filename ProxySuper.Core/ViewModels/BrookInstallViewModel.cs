﻿using MvvmCross.Commands;
using MvvmCross.ViewModels;
using ProxySuper.Core.Models;
using ProxySuper.Core.Models.Hosts;
using ProxySuper.Core.Models.Projects;
using ProxySuper.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxySuper.Core.ViewModels
{
    public class BrookInstallViewModel : MvxViewModel<Record>
    {
        Host _host;

        BrookSettings _settings;

        BrookService _service;

        public override void Prepare(Record parameter)
        {
            _host = parameter.Host;
            _settings = parameter.BrookSettings;
        }

        public override Task Initialize()
        {
            _service = new BrookService(_host, _settings);
            _service.Progress.StepUpdate = () => RaisePropertyChanged("Progress");
            _service.Progress.LogsUpdate = () => RaisePropertyChanged("Logs");
            return base.Initialize();
        }

        public override void ViewDestroy(bool viewFinishing = true)
        {
            _service.Disconnect();
            base.ViewDestroy(viewFinishing);
        }

        public ProjectProgress Progress => _service.Progress;

        public string Logs => _service.Progress.Logs;

        public IMvxCommand InstallCommand => new MvxCommand(_service.Install);

        public IMvxCommand UninstallCommand => new MvxCommand(_service.Uninstall);
    }
}
