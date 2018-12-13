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
using CodeAnalizerGUI.Interfaces;
using Moq;
namespace CodeAnalizerGUITests
{
    [TestFixture]
    class NewContributorTests
    {
        private NewContributorViewModel viewModel;
        private TestMediator mediator;
        private ContributorModel model;
        [OneTimeSetUp]
        public void LoadControl()
        {
            ControlFactory fac = new ControlFactory();
            model = new ContributorModel();
            viewModel = new NewContributorViewModel();
            viewModel.Contributor = model;
        }

        [SetUp]
        public void MediatorSetUp()
        {
            mediator = new TestMediator();
            viewModel = new NewContributorViewModel();
            viewModel.Mediator = mediator;

            var fileListMck = new Mock<ISubControlSender<List<string>>>();
            fileListMck.Setup(x => x.GetData()).Returns(new List<string>() { "" });

            viewModel.FileList = fileListMck.Object;
        }

        [Test]
        public void SendNotChangedTest()
        {
            string[] tmpPaths = new string[] { "" };

            viewModel.Send();

            ContributorModel expected = new ContributorModel();
            expected.PathsToFiles = tmpPaths.ToList();
            Assert.AreEqual(expected, mediator.recivedData);
        }

        [Test]
        public void SendWithNoFileTest()
        {
            var fileListMck = new Mock<ISubControlSender<List<string>>>();
            fileListMck.Setup(x => x.GetData()).Returns(new List<string>() {  });

            viewModel.FileList = fileListMck.Object;
            Assert.Throws(typeof(NoFileSelectedException), new TestDelegate(viewModel.Send));
        }

        [Test]
        public void CancelTest()
        {
            viewModel.Cancel();
            Assert.AreEqual(null, mediator.recivedData);
        }

        
    }
}
