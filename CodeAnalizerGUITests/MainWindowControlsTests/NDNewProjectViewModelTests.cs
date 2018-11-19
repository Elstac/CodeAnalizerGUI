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
namespace CodeAnalizerGUITests.MainWindowControlsTests
{
    [TestFixture]
    class NDNewProjectViewModelTests
    {
        private NDNewProjectViewModel toTest;
        private int closeCounter;
        [SetUp]
        public void Setup()
        {
            Mock<INewProjectConfigurationCreator> creator = new Mock<INewProjectConfigurationCreator>();
            creator.Setup(h => h.CreateConfiguration(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
            Mock<IControlsMediator> mediator = new Mock<IControlsMediator>();
            mediator.Setup(h => h.SendData(It.IsAny<object>()));

            toTest = new NDNewProjectViewModel { Creator = creator.Object,Mediator = mediator.Object };
            toTest.EndOperation += CloseMock; 
        }
        [Test]
        public void PassNDTest()
        {
            string[] par = null;
            Mock<INewProjectConfigurationCreator> creator = new Mock<INewProjectConfigurationCreator>();
            creator.Setup(h => h.CreateConfiguration(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Callback((string a1, string a2, string a3) => par = new string[] { a1, a2, a3 });
            toTest.Creator = creator.Object;

            string name = "name";
            string des = "description";
            string path = "path";

            toTest.Name = name;
            toTest.Description = des;
            toTest.Path = path;

            var po = new Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject(toTest);
            po.Invoke("ConfirmClick");

            Assert.AreEqual(new string[] { name, des, path },par);
        }
        [Test]
        public void CloseWindowAfterConfirm()
        {
            closeCounter = 0;
            toTest.Name = "a";
            toTest.Path = "[";

            var po = new Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject(toTest);
            po.Invoke("ConfirmClick");

            Assert.AreEqual(1, closeCounter);
        }
        [Test]
        public void CloseWindowAfterCancel()
        {
            closeCounter = 0;
            toTest.Name = "a";
            toTest.Path = "b";

            var po = new Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject(toTest);
            po.Invoke("CancelClick");

            Assert.AreEqual(1, closeCounter);
        }

        [Test]
        public void SendDataAfterConfirmClickTest()
        {
            object sended=null;
            Mock<IControlsMediator> mediator = new Mock<IControlsMediator>();
            mediator.Setup(h => h.SendData(It.IsAny<object>())).Callback((object par) => sended = par);

            toTest.Mediator = mediator.Object;

            var po = new Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject(toTest);
            po.Invoke("ConfirmClick");

            Assert.AreEqual(true, (bool)sended);
        }

        [Test]
        public void DontSendAnythingAfterCancel()
        {
            Mock<IControlsMediator> mediator = new Mock<IControlsMediator>();
            mediator.Setup(h => h.SendData(It.IsAny<object>()));

            toTest.Mediator = mediator.Object;

            var po = new Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject(toTest);
            po.Invoke("CancelClick");

            mediator.Verify(x => x.SendData(It.IsAny<object>()), Times.Never());
        }
        [Test]
        public void NoNameConfirmClickThrowException()
        {
            toTest.Name = "";

            var po = new Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject(toTest);

            try
            {
                po.Invoke("ConfirmClick");
            }
            catch (TargetInvocationException e)
            {
                Assert.True(e.InnerException is InvalidOperationException);
            }
        }
        [Test]
        public void NoPathConfirmClickThrowsException()
        {
            toTest.Name = "xd";
            toTest.Path = "";

            var po = new Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject(toTest);
            try
            {
                po.Invoke("ConfirmClick");
            }
            catch(TargetInvocationException e)
            {
                Assert.True(e.InnerException is InvalidOperationException);
            }
        }
        private void CloseMock()
        {
            closeCounter++;
        }
    }
}
