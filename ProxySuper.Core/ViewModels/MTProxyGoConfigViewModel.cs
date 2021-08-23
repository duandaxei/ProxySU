﻿using MvvmCross.ViewModels;
using ProxySuper.Core.Models;
using ProxySuper.Core.Models.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxySuper.Core.ViewModels
{
    public class MTProxyGoConfigViewModel : MvxViewModel<MTProxyGoSettings>
    {
        public MTProxyGoSettings Settings { get; set; }

        public override void Prepare(MTProxyGoSettings parameter)
        {
            Settings = parameter;
        }
    }
}
