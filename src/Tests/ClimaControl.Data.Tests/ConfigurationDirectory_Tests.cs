using ClimaControl.Data.Configuration;
using ClimaControl.Data.Configuration.UICore;
using ClimaControl.Data.Exceptions;
using NUnit.Framework;

namespace ClimaControl.Data.Tests
{
    [TestFixture]
    public class ConfigurationItemBase_Tests
    {
        string directoryName = "TestItem";
        string directoryHeader = "Test config item";
        string childItemName = "TestChildItem";
        string childItemHeader = "Test child Item";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateItem_Test()
        {

            var directory = new ConfigurationDirectory(directoryName, directoryHeader);

            Assert.IsNotNull(directory);
        }
        [Test]
        public void AddChildItem_Test()
        {

            var directory = new ConfigurationDirectory(directoryName, directoryHeader);
            var child = new TestConfigurationItem(childItemName, childItemHeader);

            directory.AddChildItem(child);

            Assert.IsTrue(directory.Child.ContainsKey(childItemName));
            Assert.IsInstanceOf<TestConfigurationItem>(directory.Child[childItemName]);
        }
        [Test]
        public void RemoveChildItem_Test()
        {

            var directory = new ConfigurationDirectory(directoryName, directoryHeader);
            var child = new TestConfigurationItem(childItemName, childItemHeader);

            directory.AddChildItem(child);

            directory.RemoveChildItem(childItemName);

            Assert.IsFalse(directory.Child.ContainsKey(childItemName));
        }
        [Test]
        public void ParentIsSet_Test()
        {

            var directory = new ConfigurationDirectory(directoryName, directoryHeader);
            var child = new TestConfigurationItem(childItemName, childItemHeader);

            directory.AddChildItem(child);

            Assert.AreEqual(child.Parent, directory);
        }
        [Test]
        public void DataExceptionIfAlreadyExists_Test()
        {
            var exceptionMessage = $"Child whith name:{childItemName} already exist in:{directoryName}.";
            var directory = new ConfigurationDirectory(directoryName, directoryHeader);
            var child = new TestConfigurationItem(childItemName, childItemHeader);

            directory.AddChildItem(child);

            Assert.Throws<ConfigurationDataException>(() => directory.AddChildItem(child), exceptionMessage);
        }
        [Test]
        public void DataExceptionIfItemNameNull_Test()
        {
            var exceptionMessage = $"Name cannot be empty or null";

            var directory = new ConfigurationDirectory(directoryName, directoryHeader);
            var child = new TestConfigurationItem("", childItemHeader);

            Assert.Throws<ConfigurationDataException>(() => directory.AddChildItem(child), exceptionMessage);
        }

        [Test]
        public void GetItemPath_Test()
        {
            var expectedPath = "\\" + directoryName + "\\" + childItemName;
            var directory = new ConfigurationDirectory(directoryName, directoryHeader);
            var child = new TestConfigurationItem(childItemName, childItemHeader);
            directory.AddChildItem(child);
            
            Assert.AreEqual(child.GetPath(),expectedPath);
        }
        public class TestConfigurationItem : ConfigurationItemBase
        {
            public TestConfigurationItem() : base()
            {

            }
            public TestConfigurationItem(string itemName, string header = "") : base(itemName, header)
            {

            }
        }
    }
}