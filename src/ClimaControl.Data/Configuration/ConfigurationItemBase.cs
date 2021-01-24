using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ClimaControl.Data.Exceptions;

namespace ClimaControl.Data.Configuration
{
    [DataContract]
    public abstract class ConfigurationItemBase:ObservableObject
    {
        private ConfigurationItemBase _parent;
        private readonly Dictionary<string, ConfigurationItemBase> _childConfigs;
        private string _name;
        private string _header;

        protected ConfigurationItemBase()
        {
            _childConfigs=new Dictionary<string, ConfigurationItemBase>();
            _parent = null;
        }

        protected ConfigurationItemBase(string itemName, string header = "")
        {
            _name = itemName;
            _header = header;
            _childConfigs=new Dictionary<string, ConfigurationItemBase>();
            _parent = null;
        }
        public virtual IDictionary<string,ConfigurationItemBase> Child => _childConfigs;
        [DataMember]
        public string Name
        {
            get => _name;
            set => Update(ref _name , value);
        }
        [DataMember]
        public string Header
        {
            get => _header;
            set => Update(ref _header, value);
        }

        public ConfigurationItemBase Parent
        {
            get { return _parent; }
            protected set { _parent = value; }
        }
        public virtual bool HasChild
        {
            get => _childConfigs.Count > 0;
        }

        public virtual void AddChildItem(ConfigurationItemBase item)
        {
            var itemName = item.Name.Trim();

            if (itemName == String.Empty)
            {
                throw new ConfigurationDataException("Name cannot be empty or null");
            }

            if(!_childConfigs.ContainsKey(item.Name))
            {
                
                item.Parent = this;
                _childConfigs.Add(item.Name, item);
            }
            else
            {
                throw new ConfigurationDataException($"Child whith name:{item.Name} already exist in:{Name}.");
            }
        }

        public virtual void RemoveChildItem(string itemName)
        {
            if (_childConfigs.ContainsKey(itemName))
            {
                _childConfigs.Remove(itemName);
            }
        }

        public virtual string GetPath(string pathSeparator = "\\")
        {
            string resultPath = "";
            GetPathRecurcy(ref resultPath, pathSeparator);
            return resultPath;
        }

        protected virtual void GetPathRecurcy(ref string path, string pathSeparator)
        {
            path = pathSeparator + Name + path;
            if (_parent != null)
            {
                _parent.GetPathRecurcy(ref path, pathSeparator);
            }
        }
    }
}