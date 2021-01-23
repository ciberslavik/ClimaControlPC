namespace ObjectGenerator.ItemGenerators
{
    public class ConfigurableItemNamespaces
    {

        private string _item;
        private string _itemView;
        private string _itemViewModel;
        private string _itemViewInterface;
        private string _itemViewModelInterface;
        private string _views;
        private string _viewModels;
        private string _data;

        public ConfigurableItemNamespaces()
        {
            _item = "ClimaControl.Data.Configuration";
            _itemView = "ClimaControl.UI.WPF.Views.Configuration";
            _itemViewModel = "ClimaControl.UI.Impl.Configuration";

            _itemViewInterface = "ClimaControl.UI.UICore.Views.Configuration";
            _itemViewModelInterface = "ClimaControl.UI.UICore.ViewModels.Configuration";
            _views = "ClimaControl.UI.UICore.Views";
            _viewModels = "ClimaControl.UI.UICore.ViewModels";
            _data = "ClimaControl.Data.Configuration";
        }
        public string Item
        {
            get => _item;
            set => _item = value;
        }

        public string ItemView
        {
            get => _itemView;
            set => _itemView = value;
        }

        public string ItemViewModel
        {
            get => _itemViewModel;
            set => _itemViewModel = value;
        }

        public string ItemViewInterface
        {
            get => _itemViewInterface;
            set => _itemViewInterface = value;
        }

        public string ItemViewModelInterface
        {
            get => _itemViewModelInterface;
            set => _itemViewModelInterface = value;
        }

        public string Views
        {
            get => _views;
            set => _views = value;
        }

        public string ViewModels
        {
            get => _viewModels;
            set => _viewModels = value;
        }

        public string Data
        {
            get => _data;
            set => _data = value;
        }
    }
}