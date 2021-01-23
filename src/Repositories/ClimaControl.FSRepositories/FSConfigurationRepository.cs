using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Serialization;
using ClimaControl.Data.Configuration;
using ClimaControl.UI.Services.Configuration;
using ClimaControl.UI.Services.Configuration.Model;

namespace ClimaControl.FSRepositories
{
    public class FSConfigurationRepository : IConfigurationRepository
    {
        private readonly IConfigurationSerializer _serializer;
        private readonly string _repoDir;
        private RootConfigItem _rootConfig;

        private Dictionary<string, string> _configRegistry; //Registry <ConfigPath, ConfigName>

        public FSConfigurationRepository(IConfigurationSerializer serializer, string repoDirectory = "C:\\ClimaRepo")
        {
            _repoDir = repoDirectory;
            _serializer = serializer;
            _configRegistry = new Dictionary<string, string>();
            _rootConfig = new RootConfigItem("RootConfig");
            if (!Directory.Exists(_repoDir))
            {
                Directory.CreateDirectory(_repoDir);
            }
            SaveConfigurationItem(_rootConfig);
            
        }
        public IEnumerable<T> GetConfigsFromType<T>() where T : ConfigItemBase
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ConfigItemBase> GetConfigsFromName(string name)
        {
            throw new NotImplementedException();
        }

        public ConfigItemBase GetConfigurationFromPath(string configPath)
        {
            throw new NotImplementedException();
        }

        public RootConfigItem GetConfigurationRoot()
        {
            return _rootConfig;
        }

        public T CreateConfig<T>(ConfigItemBase parent = null) where T : ConfigItemBase, new()
        {
            T item = new T();
            var itemName = typeof(T).Name;
            return CreateConfig(itemName, item, parent);
        }

        public T CreateConfig<T>(string configurationName, ConfigItemBase parent = null) where T : ConfigItemBase, new()
        {
            T item = new T();
            return CreateConfig<T>(configurationName, item, parent);
        }

        public T CreateConfig<T>(string configurationName, T instance, ConfigItemBase parent = null) where T : ConfigItemBase, new()
        {
            instance.ItemName = configurationName;
            if(parent==null)
                _rootConfig.AddChild(instance);
            else
                parent.AddChild(instance);

            NormalizeName(_rootConfig);

            SaveConfigurationItem(instance);

            IndexDirectory(_repoDir);
            return instance;
        }

        
        
        public void UpdateConfig<T>(T config)
        {
            throw new System.NotImplementedException();
        }

        private void SaveConfigurationItem(ConfigItemBase item)
        {
            string itemDirectoryPath;
            string itemFilePath;

            
            itemDirectoryPath = _repoDir + item.GetPath();
            string itemLocationPath = Path.GetDirectoryName(itemDirectoryPath);

            if (!Directory.Exists(itemLocationPath))
                Directory.CreateDirectory(itemLocationPath);

            itemFilePath = itemDirectoryPath + ".json";
            
            SaveConfigItem(itemFilePath,item);

            if (item.HasChildItems())
            {
                if (!Directory.Exists(itemDirectoryPath))
                    Directory.CreateDirectory(itemDirectoryPath);

                foreach (var childItem in item.ChildItems)
                {
                    SaveConfigurationItem(childItem);
                }
            }
        }

        private void LoadConfigurationRepository()
        {
            if(Directory.Exists(_repoDir))
            {
                //foreach (var VARIABLE in Dire)
                //{
                    
                //}
            }
        }
        private void IndexDirectory(string directoryPath)
        {
            _configRegistry.Clear();
            ConfigItemBase testRegistry = new RootConfigItem("RootConfig");

            testRegistry = IndexDirectoryRecursive(testRegistry);
        }
        private ConfigItemBase IndexDirectoryRecursive(ConfigItemBase item)
        {
            //ConfigItemBase currentItem = item;
            string itemDirectoryPath = _repoDir + item.GetPath();
            string itemFilePath = itemDirectoryPath + ".json";

            if (File.Exists(itemFilePath))
            {
                item = LoadConfigItem(itemFilePath);

                if (Directory.Exists(itemDirectoryPath))    //Has child
                {
                    foreach (var childFile in Directory.GetFiles(itemDirectoryPath)) //enumerate child files
                    {
                        var childName = Path.GetFileNameWithoutExtension(childFile);
                        ConfigItemBase childItem = new DefaultConfigItem();
                        childItem.ItemName = childName;
                        item.AddChild(childItem);
                        childItem = IndexDirectoryRecursive(childItem);
                    }
                }
            }

            return item;
        }
        private void LoadConfigurationItem(ref ConfigItemBase item)
        {
            string itemDirectoryPath;
            string itemFilePath;


            itemDirectoryPath = _repoDir + item.GetPath();
            string itemLocationPath = Path.GetDirectoryName(itemDirectoryPath);
            
            itemFilePath = itemDirectoryPath + ".json";
            if (File.Exists(itemFilePath))
            {
                item = LoadConfigItem(itemFilePath);
            }

            if (Directory.Exists(itemDirectoryPath))
            {

            }
        }

        private void NormalizeName(ConfigItemBase item)
        {
            
            if (string.IsNullOrEmpty(item.ItemName))
            {
                item.ItemName = item.GetType().Name;
            }

            if (item.HasChildItems())
            {
                foreach (var childItem in item.ChildItems)
                {
                    NormalizeName(childItem);
                }
            }
        }
        private void SaveConfigItem(string filePath, ConfigItemBase item)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.OpenOrCreate)))
            {
                writer.Write(_serializer.Serialize(item));
            }
        }

        private ConfigItemBase LoadConfigItem(string filePath)
        {
            if (File.Exists(filePath))
            {
                return _serializer.Deserialize<DefaultConfigItem>(File.ReadAllBytes(filePath));
            }
            else
            {
                return null;
            }
        }
    }
}