using Castle.Windsor;
using ClimaControl.Shell.Views;
using ClimaControl.WPF.Installers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ClimaControl.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        IWindsorContainer container = new WindsorContainer();
        protected override void OnStartup(StartupEventArgs e)
        {

            container.Install(new GenericInstaller());
            container.Install(new MVVMInstaller());

            var w = container.Resolve<IMainView>();
            
            base.OnStartup(e);
        }
    }
}
