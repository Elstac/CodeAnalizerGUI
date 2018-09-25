using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.Classes;
using CodeAnalizerGUI.UserControls.MainWindowControls.ViewModels;
using CodeAnalizerGUI.UserControls.MainWindowControls.Models;
using NUnit.Framework;
using CodeAnalizerGUI.Exceptions;
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
        }
        [Test]
        public void SendNotChangedTest()
        {
            string[] tmpPaths = new string[] { "" };
            viewModel.Contributor.PathsToFiles = tmpPaths.ToList();
            viewModel.Send();
            ContributorModel expected = new ContributorModel();
            expected.PathsToFiles = tmpPaths.ToList();
            Assert.AreEqual(expected, mediator.recivedData);
        }
        [Test]
        public void SendWithNoFileTest()
        {
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
