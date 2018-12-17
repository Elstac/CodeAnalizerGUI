using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using CodeAnalizerGUI.ProjectModule;
using System.IO;
using CodeAnalizerGUI.Classes;
using CodeAnalizerGUI.Interfaces;
using CodeAnalizerGUI;

namespace CodeAnalizerGUITests.ClassesTests
{
    [TestFixture]
    public class ProjectInitializerTests
    {
        private ProjectInitializer initializer;
        private Mock<INewProjectConfigurationCreator> creatorMock;
        private Mock<ILogicHolder> logicHolderMock;
        private Mock<IVMMediator> mediatorMock;
        private readonly string path = @"D:\Test";

        [OneTimeSetUp]
        public void Initialize()
        {
            Directory.CreateDirectory(path);

            creatorMock = new Mock<INewProjectConfigurationCreator>();

            logicHolderMock = new Mock<ILogicHolder>();

            mediatorMock = new Mock<IVMMediator>();

            initializer = new ProjectInitializer(logicHolderMock.Object, creatorMock.Object,mediatorMock.Object);
        }

        [Test]
        public void Pass_arguments_to_config_creator()
        {
            initializer.Initialize("a", "b", path);

            creatorMock.Verify(x => x.CreateConfiguration("a", "b", path), Times.Once);
        }

        [Test]
        public void Clear_logic_holder_after_creating_new_project()
        {
            initializer.Initialize("a", "", path);

            logicHolderMock.Verify(x => x.ResetHolder(), Times.Once);
        }

        [Test]
        public void Create_resource_directory_in_project_directory()
        {
            initializer.Initialize("a", "", path);

            Assert.True(Directory.Exists(path + "\\Resources"));
        }

        [Test]
        public void Send_open_project_msg_after_creation()
        {
            initializer.Initialize("a", "b", path);

            mediatorMock.Verify(x => x.NotifyColleagues(MVVMMessage.ProjectCreated, It.IsAny<ProjectConfig>()), Times.Once);
        }
        [Test]
        public void Throw_exception_after_recive__no_name()
        {
            Assert.Throws<NullReferenceException>(() => initializer.Initialize(null, "", path));
        }
        
        [Test]
        public void Throw_exception_after_recive__no_directory_path()
        {
            Assert.Throws<NullReferenceException>(() => initializer.Initialize("", "", null));
        }

        [Test]
        public void Throw_exception_after_recive__invalid_directory_path()
        {
            Assert.Throws<DirectoryNotFoundException>(() => initializer.Initialize("", "", "dupa"));
        }

        [TearDown]
        public void DestroyDirectory()
        {
            var dirs = Directory.GetDirectories(path);
            var files = Directory.GetFiles(path);

            foreach (var dir in dirs)
                Directory.Delete(dir, true);

            foreach (var file in files)
                File.Delete(file);
        }
        [OneTimeTearDown]
        public void d()
        {
            Directory.Delete(path,true);
        }
    }
}
