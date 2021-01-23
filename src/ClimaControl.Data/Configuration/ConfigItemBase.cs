using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace ClimaControl.Data.Configuration
{
    [DataContract]
    public abstract class ConfigItemBase:ObservableObject
    {
        protected ObservableCollection<ConfigItemBase> _childItems;
        protected ConfigItemBase _parentItem;
        protected string _itemName;
        protected object _itemEditorView;

        public ConfigItemBase()
        {
            _childItems=new ObservableCollection<ConfigItemBase>();
        }
        public ConfigItemBase(string itemName)
        {
            _itemName = itemName;
            _childItems = new ObservableCollection<ConfigItemBase>();
        }
        [DataMember]
        public virtual string ItemName { get=>_itemName; set=>Update(ref _itemName,value); }
        public virtual IEnumerable<ConfigItemBase> ChildItems 
        { 
            get=>_childItems;
        }

        public virtual void AddChild(ConfigItemBase child)
        {
            if (!_childItems.Contains(child))
            {
                child.ParentItem = this;
                _childItems.Add(child);
            }
        }
        protected ConfigItemBase ParentItem
        {
            get => _parentItem;
            set => Update(ref _parentItem, value);
        }

        public virtual object ItemEditorView
        {
            protected set { _itemEditorView = value; }
            get { return _itemEditorView; }
            
        }

        public virtual bool HasChildItems()
        {
            return _childItems.Count > 0;
        }

        public virtual string GetPath(string pathSeparator="\\")
        {
            string resultPath = "";
            BuildPath(ref resultPath, pathSeparator);
            return resultPath;
        }

        protected void BuildPath(ref string path, string pathSeparator)
        {
            path = pathSeparator + _itemName + path;
            if (ParentItem != null)
            {
                ParentItem.BuildPath(ref path, pathSeparator);
            }
        }
    }
}