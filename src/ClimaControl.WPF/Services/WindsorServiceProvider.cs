using Castle.Windsor;
using ClimaControl.Shell.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClimaControl.WPF.Services
{
    public class WindsorServiceProvider:IShellServiceProvider
    {
        private readonly IWindsorContainer _container;
        public WindsorServiceProvider(IWindsorContainer container)
        {
            _container = container;
        }
    }
}
