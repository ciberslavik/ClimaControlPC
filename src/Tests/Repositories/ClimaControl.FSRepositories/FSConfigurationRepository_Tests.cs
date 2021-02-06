using System.IO;
using ClimaControl.Data.Configuration;
using ClimaControl.Data.Configuration.UICore;
using ClimaControl.Data.Exceptions;
using ClimaControl.FSRepositories;
using ClimaControl.NewtonsoftJsonSerializers;
using NUnit.Framework;

namespace ClimaControl.FSRepositoriesTests
{
    public class FsConfigurationRepositoryTests
    {
        private const string _repoPath = @"C:\TestClimaRepo";
        private IConfigurationSerializer serializer;
        private FSConfigurationRepository repo;
        private string testDirectoryName = "TestDirectory";
        private string testSubDirectoryName = "SubDirectory";
        [OneTimeSetUp]
        public void InitEnvironment()
        {
            serializer = new JsonConfigurationSerializer();
        }

        [SetUp]
        public void PrepareEnvironment()
        {
            if(Directory.Exists(_repoPath))
                Directory.Delete(_repoPath,true);
            repo = new FSConfigurationRepository(serializer, _repoPath);
        }

        [Test]
        public void CreateConfigurationDirectoryInRoot_Test()
        {
            var expectedDirectoryPath = _repoPath + "\\" + testDirectoryName;
            var directory = repo.CreateDirectory(testDirectoryName);

            Assert.IsInstanceOf<ConfigurationDirectory>(directory,"Check return instance, Directory is not a instance of ConfigurationDirectory");
            Assert.AreEqual(directory.Name, testDirectoryName, "Equal item name, Directory name are not equal");
            Assert.IsTrue(Directory.Exists(expectedDirectoryPath),"Create directory, Directory cannot create in file system");
        }

        [Test]
        public void CreateConfigurationDirectoryInRootAlreadyExistException_Test()
        {
            var expectedDirectoryPath = _repoPath + "\\" + testDirectoryName;
            var directory = repo.CreateDirectory(testDirectoryName);

            Assert.Throws<ConfigurationRepositoryException>((() => repo.CreateDirectory(testDirectoryName)));
        }
        [Test]
        public void CreateConfigurationSubDirectoryInDirectory_Test()
        {
            var expectedDirectoryPath = _repoPath + "\\" + testDirectoryName + "\\" + testSubDirectoryName;
            var directory = repo.CreateDirectory(testDirectoryName);

            var subDirectory = repo.CreateDirectory(testSubDirectoryName, directory);

            Assert.IsInstanceOf<ConfigurationDirectory>(subDirectory, "Directory is not a instance of ConfigurationDirectory");
            Assert.AreEqual(subDirectory.Name, testSubDirectoryName, "Directory name are not equal");
            Assert.IsTrue(Directory.Exists(expectedDirectoryPath), "Directory cannot create in file system");
        }

        [Test]
        public void RemoveConfigurationDirectory_Test()
        {
            var expectedDirectoryPath = _repoPath + "\\" + testDirectoryName;
            var directory = repo.CreateDirectory(testDirectoryName);

            repo.RemoveDirectory(directory);

            Assert.IsFalse(Directory.Exists(expectedDirectoryPath));
        }
        [Test]
        public void RemoveConfigurationDirectoryInTree_Test()
        {
            var expectedDirectoryPath = _repoPath + "\\" + testDirectoryName + "\\" + testSubDirectoryName;
            var directory = repo.CreateDirectory(testDirectoryName);
            var subDirectory = repo.CreateDirectory(testSubDirectoryName, directory);

            repo.RemoveDirectory(subDirectory);

            Assert.IsFalse(Directory.Exists(expectedDirectoryPath));
        }

        [Test]
        public void GetConfigurationDirectoies_Test()
        {
            var expectedDirectoryPath = _repoPath + "\\" + testDirectoryName + "\\" + testSubDirectoryName;
            var directory = repo.CreateDirectory(testDirectoryName);
            var directory2 = repo.CreateDirectory(testDirectoryName + "2");
            var subDirectory = repo.CreateDirectory(testSubDirectoryName, directory);
            var subSubDirectory = repo.CreateDirectory(testSubDirectoryName, subDirectory);
            var subDirectory2 = repo.CreateDirectory(testSubDirectoryName, directory2);

            var directories = repo.GetDirectories(testSubDirectoryName);

            Assert.NotNull(directories, "Return null directory list");
            Assert.IsTrue(directories.Count == 3,"Not find all entries");
        }
    }
}