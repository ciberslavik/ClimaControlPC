using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;
using ClimaControl.Data.Configuration;
using ClimaControl.Data.Configuration.UICore;
using ClimaControl.Data.Exceptions;

namespace ClimaControl.FSRepositories
{
    public class FSConfigurationRepository : IConfigurationRepository
    {
        private readonly IConfigurationSerializer _serializer;
        private readonly string _repoDir;
        private List<RegistryConfigurationItem> _configRegistry;

        public FSConfigurationRepository(IConfigurationSerializer serializer, string repoDirectory = "C:\\ClimaRepo")
        {
            _repoDir = repoDirectory;
            _serializer = serializer;
            _configRegistry = new List<RegistryConfigurationItem>();
            
            if (!Directory.Exists(_repoDir))
            {
                Directory.CreateDirectory(_repoDir);
            }
        }

        public ConfigurationDirectory CreateDirectory(string directoryName, string header="")
        {
            var directory = new ConfigurationDirectory(directoryName);

            var directoryPath = _repoDir + "\\" + directoryName;

            CreateFSDirectory(directoryPath);
            _configRegistry.Add(new RegistryConfigurationItem(directoryName, header));
            return directory;
        }
        private void CreateFSDirectory(string directoryPath)
        {
            if (Path.IsPathFullyQualified(directoryPath))
            {
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                else
                    throw new ConfigurationRepositoryException($"Directory: {directoryPath} \r\nAlready exist.");
            }
        }
        public ConfigurationDirectory CreateDirectory(string directoryName, ConfigurationDirectory parent)
        {
            var directory = new ConfigurationDirectory(directoryName);
            
            var directoryPath = _repoDir + parent.GetPath() + "\\" + directoryName;
            CreateFSDirectory(directoryPath);
            parent.AddChildItem(directory);

            return directory;
        }

        public void RemoveDirectory(ConfigurationDirectory configurationDirectory)
        {
            var directoryPath = _repoDir + configurationDirectory.GetPath();
            var directoryName = configurationDirectory.Name;
            if (Directory.Exists(directoryPath))
            {
                Directory.Delete(directoryPath,true);
                if (configurationDirectory.Parent != null)
                {
                    configurationDirectory.RemoveChildItem(directoryName);
                }
                else
                {
                    var registryItem = _configRegistry.FirstOrDefault(e => e.Name == directoryName);
                    if (registryItem != null)
                    {
                        _configRegistry.Remove(registryItem);
                    }
                }
            }
        }

        //public T RegisterConfig<T>(string configName="") where T:ConfigItem, new()
        //{
        //    T config = new T();
        //    var configRegistryItem = new RegistryItem();
        //    if (configName == String.Empty)
        //    {
        //        configRegistryItem.Name = typeof(T).Name;
        //    }
        //    else
        //    {
        //        configRegistryItem.Name = configName;
        //    }

        //    configRegistryItem.ConfigType = typeof(T);


        //    return config;
        //}
        //public IEnumerable<T> GetConfigsFromType<T>() where T : ConfigItem
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<ConfigItem> GetConfigsFromName(string name)
        //{
        //    throw new NotImplementedException();
        //}

        //public ConfigItem GetConfigurationFromPath(string configPath)
        //{
        //    throw new NotImplementedException();
        //}

        //public ConfigItem GetConfigurationRoot()
        //{
        //    return _rootConfig;
        //}

        //public T CreateConfig<T>(ConfigItem parent = null) where T : ConfigItem, new()
        //{
        //    T item = new T();
        //    var itemName = typeof(T).Name;
        //    return CreateConfig(itemName, item, parent);
        //}

        //public T CreateConfig<T>(string configurationName, ConfigItem parent = null) where T : ConfigItem, new()
        //{
        //    T item = new T();
        //    return CreateConfig<T>(configurationName, item, parent);
        //}

        //public T CreateConfig<T>(string configurationName, T instance, ConfigItem parent = null) where T : ConfigItem, new()
        //{
        //    instance.ItemName = configurationName;
        //    if(parent==null)
        //        _rootConfig.AddChild(instance);
        //    else
        //        parent.AddChild(instance);

        //    NormalizeName(_rootConfig);

        //    SaveConfigurationItem(instance);

        //    IndexDirectory();
        //    return instance;
        //}



        //    public void UpdateConfig<T>(T config)
        //    {
        //        throw new System.NotImplementedException();
        //    }

        //    private void SaveConfigurationItem(ConfigItem item)
        //    {
        //        string itemDirectoryPath;
        //        string itemFilePath;


        //        itemDirectoryPath = _repoDir + item.GetPath();
        //        string itemLocationPath = Path.GetDirectoryName(itemDirectoryPath);

        //        if (!Directory.Exists(itemLocationPath))
        //            Directory.CreateDirectory(itemLocationPath);

        //        itemFilePath = itemDirectoryPath + ".json";

        //        SaveConfigItem(itemFilePath,item);

        //        if (item.HasChildItems())
        //        {
        //            if (!Directory.Exists(itemDirectoryPath))
        //                Directory.CreateDirectory(itemDirectoryPath);

        //            foreach (var childItem in item.ChildItems)
        //            {
        //                SaveConfigurationItem(childItem);
        //            }
        //        }
        //    }

        //    private void LoadConfigurationRepository()
        //    {
        //        if(Directory.Exists(_repoDir))
        //        {
        //            //foreach (var VARIABLE in Dire)
        //            //{

        //            //}
        //        }
        //    }

        //    private string RootPath
        //    {
        //        get { return _repoDir + _rootConfig.GetPath(); }
        //    }
        //    private void IndexDirectory()
        //    {
        //        ConfigItem testRegistry = new ConfigItem();
        //        testRegistry.ItemName = _rootConfig.ItemName;

        //        string fileName = RootPath + ".json";
        //        if (File.Exists(fileName))
        //        {
        //            testRegistry = LoadConfigItem(fileName);
        //            string dirPath = RootPath;
        //            IndexDirectoryRecursive(testRegistry, dirPath);
        //        }

        //        _rootConfig = testRegistry;
        //    }
        //    private void IndexDirectoryRecursive(ConfigItem parent, string path)
        //    {
        //        if (Directory.Exists(path))
        //        {
        //            foreach (var file in Directory.GetFiles(path))
        //            {
        //                ConfigItem item;
        //                item = _serializer.Deserialize<ConfigItem>(File.ReadAllBytes(file));
        //                parent.AddChild(item);

        //                string itemDir = Path.Combine(Path.GetDirectoryName(file), Path.GetFileNameWithoutExtension(file));
        //                IndexDirectoryRecursive(item,itemDir);
        //            }
        //        }
        //    }

        //    private void NormalizeName(ConfigItem item)
        //    {

        //        if (string.IsNullOrEmpty(item.ItemName))
        //        {
        //            item.ItemName = item.GetType().Name;
        //        }

        //        if (item.HasChildItems())
        //        {
        //            foreach (var childItem in item.ChildItems)
        //            {
        //                NormalizeName(childItem);
        //            }
        //        }
        //    }
        //    private void SaveConfigItem(string filePath, ConfigItem item)
        //    {
        //        using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.OpenOrCreate)))
        //        {
        //            writer.Write(_serializer.Serialize(item));
        //        }
        //    }

        //    private ConfigItem LoadConfigItem(string filePath)
        //    {
        //        if (File.Exists(filePath))
        //        {
        //            return _serializer.Deserialize<ConfigItem>(File.ReadAllBytes(filePath));
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        public RegistryConfigurationItem GetConfigurationRegistry()
        {
            throw new NotImplementedException();
        }

        public List<ConfigurationDirectory> GetDirectories(string directoryName)
        {
            var list = new List<ConfigurationDirectory>();
            if(_configRegistry.Count>0)
            { 
                foreach (var directoryPath in Directory.GetDirectories(_repoDir))
                {
                    var dirName = Path.GetDirectoryName(directoryPath);
                }
            }
            return list;
        }

        private void BuildDirectoriesList(List<ConfigurationDirectory> list, ConfigurationItemBase parent,
            string directoryName)
        {
            foreach (var childKey in parent.Child.Keys)
            {
                if (childKey.Equals(directoryName))
                {
                    list.Add(new ConfigurationDirectory(parent.Child[childKey]));
                }
                BuildDirectoriesList(list, parent.Child[childKey], directoryName);
            }
        }
    }
}