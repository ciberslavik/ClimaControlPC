using ClimaControl.Data;
using ClimaControl.UI.UICore;
using ClimaControl.UI.UICore.Dialogs.Models;
using ClimaControl.UI.UICore.ViewModels;
using ClimaControl.UI.UICore.Views;

namespace ClimaControl.UI.Impl.UICore.ViewModels
{
    public class MainViewModel:ObservableObject, IMainViewModel
    {
        private readonly IShell _shell;
        private string _title;
        private string _statusString;
        private RelayCommand _openConfigDialogCommand;
        private IView _view;
        public MainViewModel(IShell shell)
        {
            _shell = shell;

            var tempEditor = _shell.CreateView<IEditTemperatureGraphView>();
            if (tempEditor != null)
                View = tempEditor;
            OpenConfigDialogCommand=new RelayCommand((e)=>
            {
                var configDialog = _shell.CreateDialog<IConfigurationDialog>();
                if(configDialog!=null)
                {
                    configDialog.ShowDialog();
                }
            });
        }


        public string Title
        {
            get => _title;
            set => Update(ref _title , value);
        }

        public string StatusString
        {
            get => _statusString;
            set => Update(ref _statusString, value);
        }

        public IView View { get=>_view; set=>Update(ref _view,value); }
        public RelayCommand OpenConfigDialogCommand { get; set; }
    }
}