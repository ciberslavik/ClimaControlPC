using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ClimaControl.UI;
using ClimaControl.UI.Impl.Core;
using ClimaControl.UI.UICore.Dialogs.Models;
using ClimaControl.UI.UICore.Dialogs.Models.Security;


namespace ClimaLauncher
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IShell shell = new ClimaShell();
            if (shell.Login())
            {
                var w = shell.MainView as Window;
                if (w != null)
                {
                    w.Show();
                    MainWindow = w;
                }
            }

            base.OnStartup(e);
        }
    }
}
