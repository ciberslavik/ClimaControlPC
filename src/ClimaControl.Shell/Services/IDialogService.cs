using ClimaControl.Shell.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClimaControl.Shell.Services
{
    public interface IDialogService
    {
        T CreateDialog<T>()where T:IDialog;
    }
}
