using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.Classes;
using CodeAnalizerGUI.ViewModels;
using CodeAnalizerGUI.Models;
using NUnit.Framework;
using CodeAnalizerGUI.Exceptions;
using CodeAnalizerGUI;
using CodeAnalizerGUI.Interfaces;
using Moq;
namespace CodeAnalizerGUITests
{
    class NewContributorTests
    {
        private NewContributorViewModel viewModel;
        private Mock<IVMMediator> mediator;
        private ContributorModel model;

        private MVVMMessage sended;
        private object sendedArgs;

        private FileExplorerViewModel fe;
        
        [SetUp]
        public void MediatorSetUp()
        {
            mediator = new Mock<IVMMediator>();
            fe = null;

            mediator.Setup(h => h.NotifyColleagues(It.IsAny<MVVMMessage>(), It.IsAny<object>())).Callback((MVVMMessage msg, object args) => { sended = msg; sendedArgs = args; });
            mediator.Setup(foo => foo.Register(It.IsAny<MVVMMessage>(), It.IsAny<Action<object>>()));

            var fileListMck = new Mock<IManageableFileList>();
            fileListMck.Setup(x => x.getFilePaths()).Returns(new List<string>() { "" });
            viewModel = new NewContributorViewModel(fileListMck.Object,(string[] s)=> { return fe; },mediator.Object);
        }
        [Test]
        public void Send_New_Contributor_Msg_After_Confirm()
        {
            viewModel.Send();

            mediator.Verify(x => x.NotifyColleagues(MVVMMessage.NewContributorCreated, It.IsAny<object>()), Times.Once);
        }

        [Test]
        public void Send_Close_Msg_After_Confirm()
        {
            viewModel.Send();

            mediator.Verify(x => x.NotifyColleagues(MVVMMessage.CloseControl, It.IsAny<object>()), Times.Once);
        }

        [Test]
        public void Send_Close_Msg_After_Cancel()
        {
            viewModel.Cancel();

            mediator.Verify(x => x.NotifyColleagues(MVVMMessage.CloseControl, It.IsAny<object>()), Times.Once);
        }

        [Test]
        public void SendWithNoFileTest()
        {
            var fileListMck = new Mock<IManageableFileList>();
            fileListMck.Setup(x => x.getFilePaths()).Returns(new List<string>() { });

            viewModel.FileList = fileListMck.Object;
            Assert.Throws(typeof(NoFileSelectedException), new TestDelegate(viewModel.Send));
        }


        [Test]
        public void Send_Open_Msg_Before_Chose_Image()
        {
            viewModel.ChoseImage();

            mediator.Verify(x => x.NotifyColleagues(MVVMMessage.OpenNewControl, It.IsAny<object>()), Times.Once);
            Assert.AreEqual(fe, sendedArgs);
        }
        
    }
}
