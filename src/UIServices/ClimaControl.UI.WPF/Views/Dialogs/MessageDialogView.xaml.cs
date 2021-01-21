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
using ClimaControl.UI.UICore.Dialogs;
using ClimaControl.UI.UICore.Dialogs.ViewModels;
using ClimaControl.UI.UICore.Dialogs.Views;

namespace ClimaControl.UI.WPF.Views.Dialogs
{
    /// <summary>
    /// Логика взаимодействия для MessageDialogView.xaml
    /// </summary>
    public partial class MessageDialogView : Window,IMessageDialogView
    {
        public MessageDialogView(IMessageDialogViewModel vm)
        {
            InitializeComponent();
        }
    }
}
