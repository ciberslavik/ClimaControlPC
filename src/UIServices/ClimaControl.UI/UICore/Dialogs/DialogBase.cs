using ClimaControl.UI.UICore.ViewModels;

namespace ClimaControl.UI.UICore.Dialogs
{
    public abstract class DialogBase:IDialog
    {
        protected readonly IDialogView _view;
        protected readonly IDialogViewModel _vm;
        private string _title;
        private DialogResult _result;

        public DialogBase(IDialogView view,IDialogViewModel vm)
        {
            _view = view;
            _vm = vm;
            _view.DataContext = _vm;
        }


        public virtual bool? ShowDialog()
        {
            return _view.ShowDialog();
        }

        public virtual string Title
        {
            get => _title;
            set => _title = value;
        }

        public virtual DialogResult Result => _result;
    }
}