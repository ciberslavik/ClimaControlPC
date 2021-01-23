using System.IO;
using ClimaControl.Data.Configuration;
using ClimaControl.FSRepositories;
using ClimaControl.NewtonsoftJsonSerializers;
using ClimaControl.UI.Services.Configuration;
using NUnit.Framework;

namespace ClimaControl.FSRepositories
{
    public class FsConfigurationRepositoryTests
    {
        private const string _repoPath = @"C:\TestClimaRepo";

        [SetUp]
        public void PrepareEnvironment()
        {
            if(Directory.Exists(_repoPath))
                Directory.Delete(_repoPath,true);

        }
        [Test]
        public void CreateDefaultItem()
        {
            IConfigurationSerializer serializer = new JsonConfigurationSerializer();
            IConfigurationRepository repo = new FSConfigurationRepository(serializer,_repoPath);

            var defaultConfiguration = repo.CreateConfig<DefaultConfigItem>();

            Assert.IsTrue(File.Exists(_repoPath+@"\RootConfig\DefaultConfigItem.json"));
        }
        [Test]
        public void CreateDefaultItemWithItemName()
        {
            string itemName = "TestDefConfig";
            IConfigurationSerializer serializer = new JsonConfigurationSerializer();
            IConfigurationRepository repo = new FSConfigurationRepository(serializer, _repoPath);

            var defaultConfiguration = repo.CreateConfig<DefaultConfigItem>(itemName);

            Assert.IsTrue(File.Exists(_repoPath + @"\RootConfig\"+itemName+".json"));
        }
        [Test]
        public void CreateCustomItem()
        {
            
            IConfigurationSerializer serializer = new JsonConfigurationSerializer();
            IConfigurationRepository repo = new FSConfigurationRepository(serializer, _repoPath);

            var defaultConfiguration = repo.CreateConfig<ConfigItemTest>();

            Assert.IsTrue(File.Exists(_repoPath + @"\RootConfig\ConfigItemTest.json"));
        }
        [Test]
        public void CreateCustomItemWithItemName()
        {
            string itemName = "TestDefConfig";
            IConfigurationSerializer serializer = new JsonConfigurationSerializer();
            IConfigurationRepository repo = new FSConfigurationRepository(serializer, _repoPath);

            var defaultConfiguration = repo.CreateConfig<ConfigItemTest>(itemName);

            Assert.IsTrue(File.Exists(_repoPath + @"\RootConfig\" + itemName + ".json"));
        }
        [Test]
        public void CreateCustomItemWithInstance()
        {
            string itemName = "TestDefConfig";
           
            IConfigurationSerializer serializer = new JsonConfigurationSerializer();
            IConfigurationRepository repo = new FSConfigurationRepository(serializer, _repoPath);
            ConfigItemTest testItem = new ConfigItemTest();
            testItem.TestProperty1 = "sdfvsd";

            var defaultConfiguration = repo.CreateConfig<ConfigItemTest>(itemName, testItem);

            Assert.IsTrue(File.Exists(_repoPath + @"\RootConfig\" + itemName + ".json"));
        }
        [Test]
        public void CreateCustomItemWithInstanceAndChildItem()
        {
            string itemName = "TestDefConfig";
            
            IConfigurationSerializer serializer = new JsonConfigurationSerializer();
            IConfigurationRepository repo = new FSConfigurationRepository(serializer, _repoPath);

            ConfigItemTest testItem = new ConfigItemTest();
            testItem.TestProperty1 = "sdfvsd";

            ConfigItemTest testItem2 = new ConfigItemTest();
            testItem2.TestProperty1 = "TEST";
            testItem.AddChild(testItem2);

            var defaultConfiguration = repo.CreateConfig<ConfigItemTest>(itemName, testItem);

            Assert.IsTrue(File.Exists(_repoPath + @"\RootConfig\" + itemName + ".json"));
        }
    }
}