namespace ObjectGenerator.ItemGenerators
{
    public class ConfigurableItemFileNames
    {
        private string _item;
        private string _itemView;
        private string _itemViewCb;
        private string _itemViewModel;
        private string _itemViewInterface;
        private string _itemViewModelInterface;

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

        public string ItemViewCb
        {
            get => _itemViewCb;
            set => _itemViewCb = value;
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
    }
}