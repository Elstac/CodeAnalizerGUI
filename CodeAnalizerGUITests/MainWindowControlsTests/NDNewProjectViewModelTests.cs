using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using CodeAnalizerGUI.ProjectModule;
using CodeAnalizerGUI.Windows;
using CodeAnalizerGUI.Interfaces;
using System.Reflection;
using CodeAnalizerGUI.Classes;
using CodeAnalizerGUI.ViewModels;
using CodeAnalizerGUI.Models;
using CodeAnalizerGUI.Exceptions;
using CodeAnalizerGUI;
namespace CodeAnalizerGUITests.MainWindowControlsTests
{
    [TestFixture]
    class NDNewProjectViewModelTests
    {
        Mock<IProjectInitializer> creator;
        Mock<IVMMediator> mediator;
        private NewProjectViewModel toTest;
        [SetUp]
        public void Setup()
        {
            creator = new Mock<IProjectInitializer>();

            mediator = new Mock<IVMMediator>();

            toTest = new NewProjectViewModel(creator.Object, mediator.Object, (string[] s) => {return null; });
        }
        [Test]
        public void Pass_changed_project_details_to_creator_after_confirm()
        {
            string name = "name";
            string des = "description";
            string path = "path";

            toTest.Name = name;
            toTest.Description = des;
            toTest.Directory = path;

            var po = new Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject(toTest);
            po.Invoke("CreateProject");

            creator.Verify(x => x.Initialize(name, des, path), Times.Once);
        }

        [Test]
        public void Send_close_msg_after_confirm()
        {
            toTest.Name = "a";
            toTest.Directory = "[";

            var po = new Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject(toTest);
            po.Invoke("CreateProject");

            mediator.Verify(x => x.NotifyColleagues(MVVMMessage.CloseControl, It.IsAny<object>()), Times.Once);
        }
        [Test]
        public void Send_close_msg_after_cancel()
        {
            var po = new Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject(toTest);
            po.Invoke("Cancel");

            mediator.Verify(x => x.NotifyColleagues(MVVMMessage.CloseControl, It.IsAny<object>()), Times.Once);
        }
        
        [Test]
        public void Throw_InvalidOperationException_after_confirm_with_unset_name()
        {
            toTest.Name = "";

            var po = new Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject(toTest);

            try
            {
                po.Invoke("CreateProject");
            }
            catch (TargetInvocationException e)
            {
                Assert.True(e.InnerException is InvalidOperationException);
            }
        }
        [Test]
        public void Throw_InvalidOperationException_after_confirm_with_unset_directory()
        {
            toTest.Name = "xd";
            toTest.Directory = "";

            var po = new Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject(toTest);
            try
            {
                po.Invoke("CreateProject");
            }
            catch (TargetInvocationException e)
            {
                Assert.True(e.InnerException is InvalidOperationException);
            }
        }

        [Test]
        public void Send_opneNewControl_msg_arter_choseDirectory_click()
        {
            var po = new Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject(toTest);
            po.Invoke("OpenFileExplorer");

            mediator.Verify(x => x.NotifyColleagues(MVVMMessage.OpenNewControl, null), Times.Once);
        }
    }
}
