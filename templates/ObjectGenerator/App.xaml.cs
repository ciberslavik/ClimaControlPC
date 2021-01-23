using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ObjectGenerator.ItemGenerators;

namespace ObjectGenerator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            ConfigurableItemGenerator gen = new ConfigurableItemGenerator();
            gen.NewItemName = "TestConfiguration";
            gen.OutputFolder = @"C:\TestGen";
            var property1 = new ConfigurableItemProperty();
            property1.PropertyName = "Title";
            property1.PropertyType = "System.string";

            var property2 = new ConfigurableItemProperty();
            property2.PropertyName = "Temperature";
            property2.PropertyType = "System.double";
            gen.Properties.Add(property1);
            gen.Properties.Add(property2);

            gen.BuildModel();

            gen.GenerateCode();

            MainWindow wnd = new MainWindow(gen);

            wnd.Show();
            Type t = typeof(string);
            MessageBox.Show(t.IsClass.ToString());
            //t.
            MainWindow = wnd;
            base.OnStartup(e);
        }
    }
}
