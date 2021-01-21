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

            var w = shell.MainView as Window;
            if (w != null)
            {
                w.Show();
                MainWindow = w;
            }

            var message = shell.CreateDialog<IMessageDialog>();
            message.Title = "Test message dialog";
            message.Message = "Test MESSAGE";

            message.ShowDialog();
            
            base.OnStartup(e);
        }
    }
}
