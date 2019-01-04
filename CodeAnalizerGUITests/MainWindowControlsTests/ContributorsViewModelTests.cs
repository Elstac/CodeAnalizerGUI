using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.ViewModels;
using CodeAnalizerGUI;
using CodeAnalizerGUI.Interfaces;
using CodeAnalizerGUI.Models;
using Moq;
using NUnit.Framework;
using System.Reflection;

namespace CodeAnalizerGUITests
{
    [TestFixture]
    class ContributorsViewModelTests
    {
        private ContributorsViewModel toTest;
        private MVVMMessage sended;
        private object sendedArgs;
        private NewContributorViewModel t;
        private ContributorDetailsViewModel d;
        [OneTimeSetUp]
        public void Initialize()
        {
            var mediator = new Mock<IVMMediator>();
            var logic = new Mock<ILogicHolder>();

            t = null;
            d = null;

            logic.Setup(h => h.GetContributorList()).Returns(new List<ContributorModel>());
            mediator.Setup(h => h.NotifyColleagues(It.IsAny<MVVMMessage>(), It.IsAny<object>())).Callback((MVVMMessage msg, object args) => { sended = msg;sendedArgs = args; } );
            mediator.Setup(foo => foo.Register(It.IsAny<MVVMMessage>(), It.IsAny<Action<object>>()));
            toTest = new ContributorsViewModel(mediator.Object, logic.Object,()=> { return t; },(ContributorModel cm)=> {return d;},"");
        }

        [SetUp]
        public void ClearContributors()
        {
            toTest.Contributors.Clear();
        }

        [Test]
        public void AddNewContributor()
        {
            var op = new Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject(toTest);
            op.Invoke("NewContributor",new object[] {new ContributorModel() });

            Assert.AreEqual(1, toTest.Contributors.Count);
        }
        [Test]
        public void AddNull()
        {
            var op = new Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject(toTest);

            try
            {
                op.Invoke("NewContributor", new object[] { null });
            }
            catch (TargetInvocationException e)
            {
                Assert.True(e.InnerException is NullReferenceException);
            }
        }
        [Test]
        public void SendMeessageNewContributorControll()
        {
            var op = new Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject(toTest);
            op.Invoke("NewContributorClick");

            Assert.True(MVVMMessage.OpenNewControl== sended && sendedArgs == t);
        }
        [Test]
        public void SendMeessageWithChosenContributorAfterClickOnDetailsButton()
        {
            var op = new Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject(toTest);
            var toAdd = new ContributorButtonModel(new ContributorModel(), null);

            op.Invoke("OpenDetailsControl",new object[] { toAdd });

            Assert.True(sended == MVVMMessage.OpenNewControl && sendedArgs == d);
        }
        
    }
}
