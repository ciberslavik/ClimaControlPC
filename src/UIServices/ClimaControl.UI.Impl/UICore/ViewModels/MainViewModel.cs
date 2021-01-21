using ClimaControl.Data;
using ClimaControl.UI.UICore.ViewModels;

namespace ClimaControl.UI.Impl.UICore.ViewModels
{
    public class MainViewModel:ObservableObject, IMainViewModel
    {
        private string _title;
        private string _statusString;

        public MainViewModel()
        {
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
    }
}