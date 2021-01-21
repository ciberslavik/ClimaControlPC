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
using ClimaControl.UI.UICore.ViewModels;
using ClimaControl.UI.UICore.Views;

namespace ClimaControl.UI.WPF.Views
{
    /// <summary>
    /// Логика взаимодействия для MainView.xaml
    /// </summary>
    public partial class MainView : Window, IMainView
    {
        public MainView(IMainViewModel vm)
        {
            InitializeComponent();
        }
    }
}
