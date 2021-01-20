using ClimaControl.Shell.ViewModels.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClimaControl.Shell.Impl.ViewModels.Dialogs
{
    public class MessageDialogViewModel:IMessageDialogViewModel
    {
        private string _title;
        public string Title
        {
            get => _title;
        }
    }
}
