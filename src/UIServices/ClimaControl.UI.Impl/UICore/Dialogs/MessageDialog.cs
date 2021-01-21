using ClimaControl.UI.UICore.Dialogs;
using ClimaControl.UI.UICore.Dialogs.Models;
using ClimaControl.UI.UICore.Dialogs.ViewModels;
using ClimaControl.UI.UICore.Dialogs.Views;

namespace ClimaControl.UI.Impl.UICore.Dialogs
{
    public class MessageDialog:DialogBase, IMessageDialog
    {
        private string _title;
        private DialogResult _result;
        private string _message;
        private DialogButton _buttons;
        private readonly IMessageDialogViewModel _vm;

        public MessageDialog(IMessageDialogView view,IMessageDialogViewModel vm):base(view,vm)
        {
            _vm = vm;
        }


        public override bool? ShowDialog()
        {
            return _view.ShowDialog();
        }

        public string Title
        {
            get => _vm.Title;
            set => _vm.Title = value;
        }

        public DialogResult Result => _result;

        public string Message
        {
            get => _vm.Message;
            set => _vm.Message = value;
        }

        public DialogButton Buttons
        {
            get => _buttons;
            set => _buttons = value;
        }
    }
}