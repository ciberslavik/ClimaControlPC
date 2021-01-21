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
using ClimaControl.UI.UICore.Dialogs.ViewModels.Security;
using ClimaControl.UI.UICore.Dialogs.Views.Security;

namespace ClimaControl.UI.WPF.Views.Dialogs.Security
{
    /// <summary>
    /// Логика взаимодействия для LoginDialogView.xaml
    /// </summary>
    public partial class LoginDialogView : Window,ILoginDialogView
    {
        public LoginDialogView(ILoginDialogViewModel vm)
        {
            InitializeComponent();
            
        }
    }
}
