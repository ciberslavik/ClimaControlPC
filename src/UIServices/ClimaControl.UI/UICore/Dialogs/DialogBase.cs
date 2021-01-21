using ClimaControl.UI.UICore.ViewModels;

namespace ClimaControl.UI.UICore.Dialogs
{
    public abstract class DialogBase:IDialog
    {
        protected readonly IDialogView _view;
        protected readonly IViewModel _vm;
        private string _title;
        private DialogResult _result;

        public DialogBase(IDialogView view, IViewModel vm)
        {
            _view = view;
            _vm = vm;
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