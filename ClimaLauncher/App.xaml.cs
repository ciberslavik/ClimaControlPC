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
using ClimaControl.UI.UICore.Themes;


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
            var themes = shell.ShellThemes;
            foreach (var t in themes)
            {
                if (t.GetType().Name.Equals("DarkTheme"))
                {
                    shell.SetShellTheme(t);
                }
            }
            var w = shell.MainView as Window;
            //if (shell.Login())
            //{
                
                if (w != null)
                {
                    w.Show();
                    w.WindowState = WindowState.Maximized;
                    MainWindow = w;
                }
            //}

            
            base.OnStartup(e);
        }
    }
}
