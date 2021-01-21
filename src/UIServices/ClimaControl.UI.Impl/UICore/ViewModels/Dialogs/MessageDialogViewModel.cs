using ClimaControl.Data;
using ClimaControl.UI.UICore.Dialogs;
using ClimaControl.UI.UICore.Dialogs.ViewModels;
using ClimaControl.UI.UICore.Dialogs.Views;

namespace ClimaControl.UI.Impl.UICore.ViewModels.Dialogs
{
    public class MessageDialogViewModel:ObservableObject, IMessageDialogViewModel
    {
        private string _title;
        private string _message;

        public MessageDialogViewModel()
        {
            _title = "";
            _message = "";
        }


        public string Title
        {
            get => _title;
            set => Update(ref _title , value);
        }

        public string Message
        {
            get => _message;
            set => Update(ref _message, value);
        }
    }
}