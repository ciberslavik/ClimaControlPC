using System;

namespace ClimaControl.UI.UICore.Dialogs
{
    [Flags]
    public enum DialogButton
    {
        OkButton = 1,
        CancelButton = 2,
        RetryButton = 4,

    }
    public enum DialogResult
    {
        Accept = 1,
        Cancel = 2,
        Reject = 3,
        Retry = 4
    }
}