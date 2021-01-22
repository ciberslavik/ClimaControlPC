using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ClimaControl.UI.UICore.Dialogs.Views;

namespace ClimaLauncher.DialogCreation
{
    /// <summary>
    /// Логика взаимодействия для ConfigurationDialogView.xaml
    /// </summary>
    public partial class ConfigurationDialogView : Window, IConfigurationDialogView
    {
        public ConfigurationDialogView()
        {
            InitializeComponent();
        }
    }
}
