using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ClimaControl.UI;
using ClimaControl.UI.Impl.Core;
using ClimaControl.UI.Services.Configuration.Model;
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

            

            var rootItem = new TestConfigItem("root");
            var childItem1 = new TestConfigItem("Child1");
            var childItem2 = new TestConfigItem("Child2");
            var childItem11 = new TestConfigItem("Child11");
            var childItem12 = new TestConfigItem("Child12");
            var childItem121 = new TestConfigItem("Child121");

            childItem12.AddChild(childItem121);
            childItem1.AddChild(childItem11);
            childItem1.AddChild(childItem12);

            rootItem.AddChild(childItem1);
            rootItem.AddChild(childItem2);

            string path = childItem121.GetPath("/");
            base.OnStartup(e);
        }
    }
}
